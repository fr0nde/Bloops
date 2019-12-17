<template>
  <header>
    <div ref="headerBackgroundImages" class="header-background">
      <img class="visible" src="assets/header.png" />
      <img src="https://files.facepunch.com/s/fd9e3b8c3b66.jpg" />
      <img src="https://files.facepunch.com/s/57140e930812.jpg" />
      <img src="https://files.facepunch.com/s/ff7f56e2867a.jpg" />
    </div>
    <div class="header-content">
      <div>
        <h1>Rejoins-nous vite !</h1>
        <div class="download-buttons">
          <img height="80" src="assets/google-play-badge.png" />
          <img height="55" src="assets/app-store-badge.svg" />
        </div>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  mounted() {
    const backgroundImages = this.$refs.headerBackgroundImages.children;
    this.updateHeaderImage(backgroundImages, 0);
  },
  methods: {
    updateHeaderImage(backgroundImages, newImageIndex) {
      let oldImageIndex = newImageIndex - 1;
      if (oldImageIndex < 0) {
        oldImageIndex = backgroundImages.length - 1;
      }

      backgroundImages[oldImageIndex].classList.remove("visible");
      backgroundImages[newImageIndex].classList.add("visible");

      newImageIndex = newImageIndex + 1;
      if (newImageIndex === backgroundImages.length) {
        newImageIndex = 0;
      }

      setTimeout(
        () => this.updateHeaderImage(backgroundImages, newImageIndex),
        4000
      );
    }
  }
};
</script>

<style lang="stylus">
header {
  height: calc(100vh - 120px);
  position: relative;
}

.header-background {
  position: relative;
  height: 100%;

  > img {
    position: absolute;
    height: 100%;
    width: 100%;
    object-fit: cover;
    opacity: 0;
    transition: all 0.4s ease;

    &.visible {
      opacity: 1;
    }
  }

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

.header-content {
  position: absolute;
  height: 100%;
  z-index: 3;
  width: 100%;
  top: 0;
  color: $white;
  display: flex;
  justify-content: center;
  align-items: center;
}

.download-buttons {
  margin: 0 auto;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
