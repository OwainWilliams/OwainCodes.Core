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
	/// <summary>Settings</summary>
	[PublishedModel("settings")]
	public partial class Settings : PublishedContentModel, ISEosettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new const string ModelTypeAlias = "settings";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Settings, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Settings(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// About the site
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("aboutTheSite")]
		public virtual string AboutTheSite => this.Value<string>("aboutTheSite");

		///<summary>
		/// email
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("email")]
		public virtual string Email => this.Value<string>("email");

		///<summary>
		/// facebook
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("facebook")]
		public virtual string Facebook => this.Value<string>("facebook");

		///<summary>
		/// github
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("github")]
		public virtual string Github => this.Value<string>("github");

		///<summary>
		/// instagram
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("instagram")]
		public virtual string Instagram => this.Value<string>("instagram");

		///<summary>
		/// linkedin
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("linkedin")]
		public virtual string Linkedin => this.Value<string>("linkedin");

		///<summary>
		/// Location
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("location")]
		public virtual string Location => this.Value<string>("location");

		///<summary>
		/// Site Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("siteTitle")]
		public virtual string SiteTitle => this.Value<string>("siteTitle");

		///<summary>
		/// twitter
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("twitter")]
		public virtual string Twitter => this.Value<string>("twitter");

		///<summary>
		/// Hide from search
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("hideFromSearch")]
		public virtual bool HideFromSearch => global::Umbraco.Web.PublishedModels.SEosettings.GetHideFromSearch(this);

		///<summary>
		/// Hide from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.3")]
		[ImplementPropertyType("umbracoNaviHide")]
		public virtual bool UmbracoNaviHide => global::Umbraco.Web.PublishedModels.SEosettings.GetUmbracoNaviHide(this);
	}
}
