<template>
  <div>
    <div class="social-networks">
      <div class="container social-networks-container">
        <img src="/assets/facebook.png" />
        <img src="/assets/instagram.png" />
      </div>
    </div>
    <nav>
      <div class="nav-content container">
        <a href="/"><img src="/assets/logo.png" height="60"/></a>
        <div class="nav-links">
          <div><a href="/blog">blog</a></div>
        </div>
      </div>
    </nav>
  </div>
</template>

<style lang="stylus">
.social-networks {
  height: 40px;
  background: $black;

  &-container {
    height: 100%;
    display: flex;
    justify-content: flex-end;
    align-items: center;

    > img {
      height: 24px;
      margin-left: 10px;
    }
  }
}

nav {
  height: 80px;
  background: $blue;
}

.nav-content {
  height: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.nav-links {
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  align-items: center;
  font-family: 'Luckiest Guy', cursive;
  color: $white;

  > div {
    margin-left: 40px;
    font-size: 1.4em;
  }
}
</style>
