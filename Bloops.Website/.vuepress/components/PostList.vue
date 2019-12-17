<template>
  <div>
    <div class="post" v-for="post in posts">
      <div class="post-image"><img :src="post.frontmatter.image"></img></div>
      <div class="post-content">
        <h3><a v-bind:href="post.path">{{ post.title }}</a></h3>
        <div class="post-details">
          <div>{{ formatDate(post.frontmatter.date) }}</div>
          <div class="tags"><span v-for="tag in post.frontmatter.tags">{{tag}}</span></div>
        </div>
        <p>{{post.frontmatter.summary}}</p>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  computed: {
    posts() {
      return this.$site.pages
        .filter(page => page.path.startsWith("/blog/") && page.path.length > 6)
        .sort((x, y) =>
          new Date(x.frontmatter.date) < new Date(x.frontmatter.date) ? 1 : -1
        );
    }
  },
  methods: {
    formatDate(date) {
      return new Intl.DateTimeFormat(navigator.language).format(new Date(date));
    }
  }
};
</script>

<style lang="stylus">
.post {
  display: flex;
  margin-bottom: 40px;
  height: 256px;
}

.post-image {
  flex: 2;
  max-height: 100%;
  object-fit: cover;
  overflow: hidden;
  margin-right: 20px;
}

.post-content {
  flex: 3;
  text-align: justify;
}
</style>
