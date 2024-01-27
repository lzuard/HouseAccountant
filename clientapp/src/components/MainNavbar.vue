<template>
    <div id="navbar-container">
        <div id="left"
            @click="$router.push('/')">
            House accountant
        </div>
        <div id="right">
        <div class="Navbar">
            <div class="NavbarItem"
                 @click="$router.push('/GridPage')">
                <label>Таблица</label>
            </div>
            <div class="NavbarItem">
                <label>Обзор</label>
            </div>
            <div class="NavbarItem"
                @click="$router.push('/UploadPage')">
                <label>Загрузить данные</label>
            </div>
        </div>
        <UserProfile/>
    </div>
    </div>
</template>

<script>
    import UserProfile from "@/components/UserProfile"

    export default{
        components:{
            UserProfile
        }
    }

</script>

<style scoped>
    * {
        font-size: 20px;
    }
    #left{
        color: var(--black-1);
        display: flex;
        align-items: center;
        margin-left: 10px;
        user-select: None;
    }
    #left:hover{
        color: var(--black-3);
    }
    #right{
        display: flex;
    }
    #navbar-container {
        display: flex;
        justify-content: space-between;
        background-color: var(--black-6);
    }
    .Navbar{
        display: flex;
    }
    .NavbarItem {
        margin: 8px;
        display: flex;
        align-items: center;
        color: var(--black-3);
    }
        .NavbarItem label {
            margin: 10px;
            user-select: none;
        }
        .NavbarItem:hover {
            color: var(--black-4)
        }
        .NavbarItem:active{
            color: var(--black-2);
        }

</style>