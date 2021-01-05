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
	// Mixin Content Type with alias "pageContent"
	/// <summary>Page Content</summary>
	public partial interface IPageContent : IPublishedContent
	{
		/// <summary>Banner Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		string BannerHeading { get; }

		/// <summary>Banner Height</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		bool BannerHeight { get; }

		/// <summary>Banner Sub Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		string BannerSubHeading { get; }

		/// <summary>Banner Summary</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		global::System.Web.IHtmlString BannerSummary { get; }

		/// <summary>Page Banner</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		global::Umbraco.Core.Models.PublishedContent.IPublishedContent PageBanner { get; }

		/// <summary>Page Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		string PageDescription { get; }
	}

	/// <summary>Page Content</summary>
	[PublishedModel("pageContent")]
	public partial class PageContent : PublishedContentModel, IPageContent
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new const string ModelTypeAlias = "pageContent";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<PageContent, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public PageContent(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Banner Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerHeading")]
		public string BannerHeading => GetBannerHeading(this);

		/// <summary>Static getter for Banner Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static string GetBannerHeading(IPageContent that) => that.Value<string>("bannerHeading");

		///<summary>
		/// Banner Height
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerHeight")]
		public bool BannerHeight => GetBannerHeight(this);

		/// <summary>Static getter for Banner Height</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static bool GetBannerHeight(IPageContent that) => that.Value<bool>("bannerHeight");

		///<summary>
		/// Banner Sub Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerSubHeading")]
		public string BannerSubHeading => GetBannerSubHeading(this);

		/// <summary>Static getter for Banner Sub Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static string GetBannerSubHeading(IPageContent that) => that.Value<string>("bannerSubHeading");

		///<summary>
		/// Banner Summary
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("bannerSummary")]
		public global::System.Web.IHtmlString BannerSummary => GetBannerSummary(this);

		/// <summary>Static getter for Banner Summary</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static global::System.Web.IHtmlString GetBannerSummary(IPageContent that) => that.Value<global::System.Web.IHtmlString>("bannerSummary");

		///<summary>
		/// Page Banner
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("pageBanner")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent PageBanner => GetPageBanner(this);

		/// <summary>Static getter for Page Banner</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static global::Umbraco.Core.Models.PublishedContent.IPublishedContent GetPageBanner(IPageContent that) => that.Value<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>("pageBanner");

		///<summary>
		/// Page Description: used for MetaData
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		[ImplementPropertyType("pageDescription")]
		public string PageDescription => GetPageDescription(this);

		/// <summary>Static getter for Page Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.9.0")]
		public static string GetPageDescription(IPageContent that) => that.Value<string>("pageDescription");
	}
}
