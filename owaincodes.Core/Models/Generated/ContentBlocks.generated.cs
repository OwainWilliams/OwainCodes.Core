//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.13.0
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
	// Mixin Content Type with alias "contentBlocks"
	/// <summary>Content Blocks</summary>
	public partial interface IContentBlocks : IPublishedContent
	{
		/// <summary>Content</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		global::Umbraco.Core.Models.Blocks.BlockListModel Content { get; }
	}

	/// <summary>Content Blocks</summary>
	[PublishedModel("contentBlocks")]
	public partial class ContentBlocks : PublishedContentModel, IContentBlocks
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const string ModelTypeAlias = "contentBlocks";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ContentBlocks, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public ContentBlocks(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("content")]
		public virtual global::Umbraco.Core.Models.Blocks.BlockListModel Content => GetContent(this);

		/// <summary>Static getter for Content</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public static global::Umbraco.Core.Models.Blocks.BlockListModel GetContent(IContentBlocks that) => that.Value<global::Umbraco.Core.Models.Blocks.BlockListModel>("content");
	}
}
