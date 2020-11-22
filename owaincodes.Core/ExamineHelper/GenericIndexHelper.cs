using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace owaincodes.Core.ExamineHelper
{
    internal class GenericIndexHelper
    {

        internal static void HandleKey(IndexingItemEventArgs e, IPublishedContent content, ILogger logService)
        {
            try
            {
                if (content != null)
                    e.ValueSet.Add("keyCleaned", content.Key.ToString("N"));
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting cleaned key - {content.Id}");
            }
        }


        internal static void HandleName(IndexingItemEventArgs e, IPublishedContent content, ILogger logService)
        {
            try
            {
                e.ValueSet.Add("nodeName", content.Name);
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting sortable name - {content.Id}");
            }
        }
        internal static void HandleLastUpdatedDate(IndexingItemEventArgs e, IPublishedContent content, ILogger logService)
        {
            try
            {
                e.ValueSet.Add(Constants.DateUpdated, content.UpdateDate.Ticks);
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting sortable last updated date - {content.Id}");
            }
        }

        internal static void HandleSort(IndexingItemEventArgs e, IPublishedContent content, ILogger logService)
        {
            try
            {
                e.ValueSet.Add(Constants.Sort, content.SortOrder);
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting sortable sort - {content.Id}");
            }
        }
        internal static void HandleMultiNodeTreePicker(IndexingItemEventArgs e, IPublishedContent content, string property, IUmbracoContextFactory umbracoContextFactory, ILogger logService)
        {
            try
            {
                var processed = new List<object>();
                if (content.HasProperty(property) && content.HasValue(property))
                {
                    IPublishedContent categoryNode;

                    using (var umbracoContextReference = umbracoContextFactory.EnsureUmbracoContext())
                    {
                        foreach (var entry in e.ValueSet.Values[property].Cast<string>())
                        {
                            foreach (var processedEntry in entry.Split(',').Select(s => GuidUdi.Parse(s)))
                            {
                                categoryNode = umbracoContextReference.UmbracoContext.Content.GetById(processedEntry.Guid);
                                if(categoryNode != null)
                                    processed.Add(categoryNode.Name.Replace(" ", ""));
                            }
                        }
                    }

                    e.ValueSet.Values.Add($"{property}Cleaned", processed);
                }
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error Handle {property} - {content.Id}");
            }
        }

        internal static void HandleParent(IndexingItemEventArgs e, IPublishedContent content, ILogger logService)
        {
            try
            {
                if(content != null)
                    if(content.Parent != null)
                        if(content.Parent.Key != null)
                        e.ValueSet.Add(Constants.Parent, content.Parent.Key.ToString("N"));
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting searchable parent - {content.Id}");
            }
        }

        internal static void ApplyCustomSortWeighting(IndexingItemEventArgs e, int contentId, int sortWeight, IProfilingLogger logService)
        {
            try
            {
                e.ValueSet.Add(Constants.CustomSort, sortWeight);
            }
            catch (Exception ex)
            {
                logService.Error(typeof(GenericIndexHelper), ex, $"Error setting sortable sort - {contentId}");
            }
        }
    }
}