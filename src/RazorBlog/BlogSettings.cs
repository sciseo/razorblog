/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/tidyui/razorblog
 * 
 */

namespace RazorBlog
{
    public class BlogSettings
    {
        /// <summary>
        /// Gets/sets the URL prefix for the entire blog.
        /// </summary>
        public string BlogPrefix { get; set; } = "/";

        /// <summary>
        /// Gets/sets the URL slug for the blog archive.
        /// </summary>
        public string ArchiveSlug { get; set; } = "/archive";

        /// <summary>
        /// Gets/sets the page size for the post listing.
        /// </summary>
        public int PageSize { get; set; } = 5;

        /// <summary>
        /// Gets/sets the currently active theme.
        /// </summary>
        public string Theme { get; set; } = "Persona";
    }
}