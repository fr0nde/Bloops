const slugify = require('slugify')
module.exports = {
  title: 'Bloops',
  themeConfig: {
    activeHeaderLinks: false
  },
  plugins: [
    {
      extendPageData(pageCtx) {
        if (
          pageCtx.regularPath.startsWith('/blog/') &&
          pageCtx.regularPath.length > 6
        ) {
          const slug = slugify(pageCtx.title, { lower: true })
          Object.assign(pageCtx.frontmatter, {
            layout: 'Post',
            permalink: `/blog/${slug}`
          })
        }
      }
    }
  ]
}
