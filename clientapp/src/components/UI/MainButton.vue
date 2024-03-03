<template>
    <button class="main-button" :disabled="!isActive">
        <slot></slot>
    </button>
</template>

<script>
    export default {
        name: "main-button",
        props:{
            isActive:{
                type: Boolean,
                default: true
            }
        }
    }

</script>

<style scoped>
    .main-button {
        padding: 5px 10px;
        background: var(--blue-3);
        color: black;
        border: 1px solid var(--blue-3);
        border-radius: 10px;
        margin: 2px;
        font-size: 15px;
    }
    .main-button:hover {
        background: var(--blue-4);
        border: 1px solid var(--blue-4);
    }
    .main-button:active {
        background: var(--blue-3);
        border: 1.5px solid var(--blue-3);
    }
    .main-button:disabled{
        background-color: var(--blue-4);
        border: 1.5px solid var(--blue-4);
        color: var(--white-1)
    }
</style>