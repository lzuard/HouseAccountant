<template>
    <MainNavbar />
    <router-view />
</template>

<script>
    import MainNavbar from "@/components/MainNavbar.vue"

    export default {
        components: {
            MainNavbar
        }
    }
</script>

<style>
    body {
        font-family: sans-serif;
        margin: 0;
        background-color: var(--black-5);
    }
</style>
