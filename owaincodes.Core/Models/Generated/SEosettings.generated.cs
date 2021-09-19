//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.14.3
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
	// Mixin Content Type with alias "sEOSettings"
	/// <summary>SEO settings</summary>
	public partial interface ISEosettings : IPublishedContent
	{
		/// <summary>Hide from search</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		bool HideFromSearch { get; }

		/// <summary>Hide from navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		bool UmbracoNaviHide { get; }
	}

	/// <summary>SEO settings</summary>
	[PublishedModel("sEOSettings")]
	public partial class SEosettings : PublishedContentModel, ISEosettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new const string ModelTypeAlias = "sEOSettings";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<SEosettings, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public SEosettings(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Hide from search
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("hideFromSearch")]
		public virtual bool HideFromSearch => GetHideFromSearch(this);

		/// <summary>Static getter for Hide from search</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public static bool GetHideFromSearch(ISEosettings that) => that.Value<bool>("hideFromSearch");

		///<summary>
		/// Hide from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("umbracoNaviHide")]
		public virtual bool UmbracoNaviHide => GetUmbracoNaviHide(this);

		/// <summary>Static getter for Hide from navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public static bool GetUmbracoNaviHide(ISEosettings that) => that.Value<bool>("umbracoNaviHide");
	}
}
