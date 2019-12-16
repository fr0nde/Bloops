<template>
  <div :class="['separator', { large }]"></div>
</template>

<script>
export default {
  props: ['large']
}
</script>

<style lang="stylus">
.separator {
  height: 100px;
  background: linear-gradient(0deg, rgba(58, 47, 38, 0.8), rgba(58, 47, 38, 0.8)), url('/assets/separator-background.png');
  background-size: cover;
  background-position: bottom;
  &.large {
    height: 200px;
  }
}
</style>
