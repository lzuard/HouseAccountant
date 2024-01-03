<template>
    <div id="profile-container">
        <img src="@/assets/user-icon-example.jpg"/>
        <label>Никифоров А.В.</label>
    </div>
</template>

<script>
</script>

<style scoped>
    img{
        border-radius: 50%;
        width: 50px;
        height: 50px;
        margin: 0 10px 0 0;
        user-select: none;
    }
    #profile-container {
        border: solid 0px black;
        border-radius: 30px;
        padding: 5px;
        margin: 5px;
        display: flex;
        align-items: center;
        background-color: #2a8afa;
    }
    #container label{
        user-select: none;
        width: 200px
    }
</style>