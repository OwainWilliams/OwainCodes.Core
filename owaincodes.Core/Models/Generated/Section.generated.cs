//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.9.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Section</summary>
	[PublishedModel("section")]
	public partial class Section : PublishedContentModel, IContentBlocks, IPageContent, ISEosettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new const string ModelTypeAlias = "section";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Section, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Section(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("content")]
		public global::Umbraco.Core.Models.Blocks.BlockListModel Content => global::Umbraco.Web.PublishedModels.ContentBlocks.GetContent(this);

		///<summary>
		/// Banner Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerHeading")]
		public string BannerHeading => global::Umbraco.Web.PublishedModels.PageContent.GetBannerHeading(this);

		///<summary>
		/// Banner Height
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerHeight")]
		public bool BannerHeight => global::Umbraco.Web.PublishedModels.PageContent.GetBannerHeight(this);

		///<summary>
		/// Banner Sub Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerSubHeading")]
		public string BannerSubHeading => global::Umbraco.Web.PublishedModels.PageContent.GetBannerSubHeading(this);

		///<summary>
		/// Banner Summary
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerSummary")]
		public global::System.Web.IHtmlString BannerSummary => global::Umbraco.Web.PublishedModels.PageContent.GetBannerSummary(this);

		///<summary>
		/// Page Banner
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("pageBanner")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent PageBanner => global::Umbraco.Web.PublishedModels.PageContent.GetPageBanner(this);

		///<summary>
		/// Page Description: used for MetaData
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("pageDescription")]
		public string PageDescription => global::Umbraco.Web.PublishedModels.PageContent.GetPageDescription(this);

		///<summary>
		/// Hide from search
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("hideFromSearch")]
		public bool HideFromSearch => global::Umbraco.Web.PublishedModels.SEosettings.GetHideFromSearch(this);

		///<summary>
		/// Hide from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide => global::Umbraco.Web.PublishedModels.SEosettings.GetUmbracoNaviHide(this);
	}
}
