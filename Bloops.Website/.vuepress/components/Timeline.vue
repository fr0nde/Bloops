<template>
  <div class="container" id="blog">
    <div class="timeline-title"><h2>Les derniers articles</h2></div>
    <div class="timeline">
      <div class="timeline-item" v-for="post in lastPosts">
        <div class="timeline-dot"></div>
        <div class="timeline-content">
          <div class="timeline-img">
            <img src="assets/header.png" />
          </div>
          <a v-bind:href="post.path">{{ post.title }}</a>
        </div>
      </div>
    </div>
    <div class="timeline-see-more"><a href="/blog">voir plus</a></div>
  </div>
</template>

<script>
export default {
  computed: {
    lastPosts() {
      return this.$site.pages
        .filter(page => page.path.startsWith('/blog/') && page.path.length > 6)
        .sort((x, y) => (x.frontmatter.date > x.frontmatter.date ? 1 : -1))
        .slice(0, 3)
    }
  }
}
</script>

<style lang="stylus">
.timeline-title {
  text-align: center;
  margin: 32px 0;
}

.timeline {
  position: relative;

  &::before {
    content: '';
    background: $blue;
    width: 5px;
    height: 95%;
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    border-radius: 100px;
  }
}

.timeline-item {
  &:nth-child(even) {
    .timeline-content {
      float: right;
      margin-right: 30px;

      &::after {
        content: '';
        position: absolute;
        border-style: solid;
        width: 0;
        height: 0;
        top: 30px;
        left: -15px;
        border-width: 10px 15px 10px 0;
        border-color: transparent $blue transparent transparent;
      }
    }
  }

  &::after {
    content: '';
    display: block;
    clear: both;
  }
}

.timeline-dot {
  width: 30px;
  height: 30px;
  background: $blue;
  border-radius: 50%;
  position: absolute;
  left: 50%;
  margin-top: 25px;
  margin-left: -15px;
}

.timeline-content {
  position: relative;
  width: 40%;
  padding: 10px;
  margin-left: 30px;
  background: $blue;
  color: $white;

  &::after {
    content: '';
    position: absolute;
    border-style: solid;
    width: 0;
    height: 0;
    top: 30px;
    right: -15px;
    border-width: 10px 0 10px 15px;
    border-color: transparent transparent transparent $blue;
  }
}

.timeline-img {
  max-height: 256px;
  object-fit: cover;
  overflow: hidden;
  margin-bottom: 10px;
}

.timeline-see-more {
  text-align: center;
  font-size: 1.4em;
  margin: 32px 0;
}
</style>
