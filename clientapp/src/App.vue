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
        margin: 0;
        background-color: #181818;
    }
</style>
