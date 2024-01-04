<template>
    <button class="main-button">
        <slot></slot>
    </button>
</template>

<script>
    export default {
        name: "main-button"
    }

</script>

<style scoped>
    .main-button {
        padding: 5px 10px;
        background: var(--colors-light-blue);
        color: white;
        border: 1px solid var(--colors-light-blue);
        border-radius: 10px;
        margin: 2px;
        font-size: 15px;
    }
    .main-button:hover {
        background: var(--colors-middle-blue);
        border: 1px solid var(--colors-middle-blue);
    }
    .main-button:active {
        background: var(--colors-dark-blue);
        border: 1.5px solid var(--colors-dark-blue);
    }
</style>