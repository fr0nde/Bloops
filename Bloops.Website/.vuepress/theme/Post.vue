<template>
  <div>
    <Navbar />
    <div class="blog">
      <div class="container" style="max-width: 1000px">
        <div class="post-header">
          <img :src="this.$frontmatter.image" />
          <div class="post-header-content">
            <h2>
              {{ this.$frontmatter.title }}
            </h2>
            <div class="post-details">
              <div>{{ formatDate(this.$frontmatter.date) }}</div>
            </div>
          </div>
        </div>
        <Content style="margin: 20px 0px; text-align: justify" />
      </div>
    </div>
    <footer>Flanic Games</footer>
  </div>
</template>

<script>
export default {
  methods: {
    formatDate(date) {
      return new Intl.DateTimeFormat(navigator.language).format(new Date(date));
    }
  }
};
</script>

<style lang="stylus">
.post-header {
  position: relative;
  max-height: 512px;
  object-fit: cover;
  overflow: hidden;

  &:after {
    content: '';
    top: 0;
    left: 0;
    z-index: 2;
    width: 100%;
    height: 100%;
    display: block;
    position: absolute;
    background: $black;
    opacity: 0.4;
  }
}

.post-header-content {
  position: absolute;
  height: 100%;
  width: 100%;
  top: 0;
  left: 0;
  z-index: 4;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
</style>