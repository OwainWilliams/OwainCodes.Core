using ClientDependency.Core.Logging;
using System;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence.Querying;
using Umbraco.Core.Scoping;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.Components
{
    public class CreateDateContentFolderComponent : IComponent
    {

        private readonly ILogger logService;

        public CreateDateContentFolderComponent(ILogger logService)
        {
            this.logService = logService;
        }


        public CreateDateContentFolderComponent(IScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider ?? throw new ArgumentNullException(nameof(scopeProvider));
        }

        public void Initialize()
        {
            ContentService.Saving += ContentService_Saving;

        }


        private IContentService contentService;
        private readonly IScopeProvider scopeProvider;

        private void ContentService_Saving(IContentService sender, ContentSavingEventArgs e)
        {

            contentService = sender;
            using (var scope = scopeProvider.CreateScope())
            {

                foreach (var node in e.SavedEntities)
                {

                    var parentNodeId = node.ParentId;


                    // If the document type is a resourceItem
                    if (node.ContentType.Alias == BlogPage.ModelTypeAlias)
                    {
                        string parentModelTypeAlias = String.Empty;
                        string modelTypeAlias = String.Empty;
                        string datePropertyTypeAlias = String.Empty;

                        switch (node.ContentType.Alias)
                        {
                            case BlogPage.ModelTypeAlias:
                                modelTypeAlias = BlogPage.ModelTypeAlias;
                                parentModelTypeAlias = Section.ModelTypeAlias;
                                datePropertyTypeAlias = BlogPage.GetModelPropertyType(r => r.PublishedDate).Alias;
                                break;
                            default:
                                throw new Exception("Error setting Model/Prop alias");
                        }


                        IContent monthFolder;

                        if (parentNodeId <= 0 && e.CanCancel)
                        {
                            e.CancelOperation(new EventMessage("Error", "Something went wrong with publishing the resource", EventMessageType.Error));
                        }

                        var currentParent = GetCurrentParent(parentNodeId);
                        var date = node.GetValue<DateTime>(datePropertyTypeAlias);

                        if (date == DateTime.MinValue)
                        {
                            date = DateTime.Today;
                            node.SetValue(datePropertyTypeAlias, date);
                        }
                        var dateYear = date.ToString("yyyy");
                        var dateMonth = date.ToString("MMMM");

                        if (currentParent.ContentType.Alias == DateFolder.ModelTypeAlias)
                        {
                            bool moveNode = VerifyOrMoveToCorrectLocation(scope, currentParent, dateYear, dateMonth, out monthFolder);

                            if (moveNode)
                                node.SetParent(monthFolder);
                        }

                        else if (currentParent.ContentType.Alias == parentModelTypeAlias)
                        {
                            monthFolder = MoveToCorrectLocation(scope, currentParent, dateYear, dateMonth);

                            node.SetParent(monthFolder);
                        }

                    }


                }
                scope.Complete();
            }

        }



        private IContent MoveToCorrectLocation(IScope scope, IContent currentParent, string dateYear, string dateMonth)
        {
            IContent monthFolder;
            var isNew = GetDateFolder(currentParent, dateYear, scope, out var folder);
            if (isNew)
            {
                monthFolder = CreateDateFolder(folder, dateMonth);
            }
            else
            {
                GetDateFolder(folder, dateMonth, scope, out monthFolder);
            }

            return monthFolder;
        }

        private bool VerifyOrMoveToCorrectLocation(IScope scope, IContent currentParent, string dateYear, string dateMonth, out IContent monthFolder)
        {
            var moveNode = true;
            var currentMonthFolder = currentParent;
            var currentMonthFoldersParent = GetCurrentParent(currentParent.ParentId);

            if (currentMonthFolder.Name.InvariantEquals(dateMonth) && currentMonthFoldersParent.Name.InvariantEquals(dateYear))
            {
                monthFolder = null;
                moveNode = false;
            }
            //Wrong month right year
            else if (!currentMonthFolder.Name.InvariantEquals(dateMonth) && currentMonthFoldersParent.Name.InvariantEquals(dateYear))
            {
                GetDateFolder(currentMonthFoldersParent, dateMonth, scope, out monthFolder);
            }
            else
            {
                var parentOfParent = GetCurrentParent(currentMonthFoldersParent.ParentId);
                GetDateFolder(parentOfParent, dateYear, scope, out var yearFolder);
                GetDateFolder(yearFolder, dateMonth, scope, out monthFolder);
            }

            return moveNode;
        }

        private bool GetDateFolder(IContent parentNode, string nodeName, IScope scope, out IContent folder)
        {
            var dateFolderTypeId = DateFolder.GetModelContentType().Id;
            var matchingChild = contentService.GetPagedChildren(parentNode.Id, 0, int.MaxValue, out _,
                new Query<IContent>(scope.SqlContext).Where(c => c.Name.InvariantEquals(nodeName) && c.Trashed == false && c.ContentTypeId == dateFolderTypeId));
            if (matchingChild == null || matchingChild.Count() <= 0)
            {
                folder = CreateDateFolder(parentNode, nodeName);
                return true;

            }

            folder = matchingChild.FirstOrDefault();
            return false;
        }

        private IContent CreateDateFolder(IContent parentNode, string name)
        {
            IContent dateFolder = contentService.Create(name, parentNode.Id, "DateFolder");
            contentService.SaveAndPublish(dateFolder);

            return dateFolder;
        }



        private IContent GetCurrentParent(int parentId)
        {
            return contentService.GetById(parentId);
        }


        public void Terminate()
        {
            //unsubscribe during shutdown
            ContentService.Saving -= ContentService_Saving;
        }
    }
}
