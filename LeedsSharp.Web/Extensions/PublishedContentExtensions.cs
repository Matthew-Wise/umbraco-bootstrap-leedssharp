using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace LeedsSharp.Web.Extensions
{
    public static class PublishedContentExtensions
    {
        public static Dictionary<string, bool> GetBlocksWithGroupNames(this IPublishedContent contentItem, string gridAlias)
        {
            var blocks = new Dictionary<string, bool>();

            var contentProperty = contentItem.Properties.FirstOrDefault(x => x.Alias == gridAlias);
            if (contentProperty == null) return blocks;

            if (contentProperty.PropertyType.DataType.ConfigurationObject is not BlockGridConfiguration config) return blocks;

            foreach (var item in config.Blocks)
            {
                blocks.Add(item.ContentElementTypeKey.ToString(), item.AllowAtRoot);
            }

            return blocks;
        }
    }
}
