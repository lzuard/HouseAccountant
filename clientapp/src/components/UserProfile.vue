<template>
    <div id="profile-container">
        <img src="@/assets/user-icon-example.jpg"/>
    </div>
</template>

<script>
</script>

<style scoped>
#profile-container{
    margin: 3px;
}
img{
    border-radius: 50%;
    width: 50px;
    height: 50px;
    user-select: none;
    border: solid 3px var(--blue-3)
}
img:hover{
    border: solid 3px var(--blue-2)
}
</style>