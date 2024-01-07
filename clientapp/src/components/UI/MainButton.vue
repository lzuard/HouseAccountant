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
        background: var(--color-blue-light);
        color: white;
        border: 1px solid var(--color-blue-light);
        border-radius: 10px;
        margin: 2px;
        font-size: 15px;
    }
    .main-button:hover {
        background: var(--color-blue-middle);
        border: 1px solid var(--color-blue-middle);
    }
    .main-button:active {
        background: var(--color-blue-dark);
        border: 1.5px solid var(--color-blue-dark);
    }
</style>