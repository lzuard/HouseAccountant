<template>
    <div id="navbar-container">
        <div class="Navbar">
            <div class="NavbarItem"
                 @click="$router.push('/')">
                <label>Main Page</label>
            </div>
            <div class="NavbarItem"
                 @click="$router.push('/GridPage')">
                <label>Grid</label>
            </div>
            <div class="NavbarItem">
                <label>Some other page</label>
            </div>
            <div class="NavbarItem">
                <label>Small Page</label>
            </div>
            <div class="NavbarItem">
                <label>Last Page</label>
            </div>
        </div>
        <UserProfile/>
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
        font-family: sans-serif
    }
    #navbar-container {
        display: flex;
        justify-content: space-between;
        background-color: #286dbd;
    }
    .Navbar{
        display: flex;
    }
    .NavbarItem {
        margin: 10px 5px 20px 25px;
        padding: 5px;
        border: solid 1px #286dbd;
        border-radius: 10px;
        background-color: #2a8afa;
    }
        .NavbarItem label {
            margin: 10px;
            user-select: none;
        }
        .NavbarItem:hover {
            background-color: #04428a;
        }

</style>