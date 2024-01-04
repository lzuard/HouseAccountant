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
            <div class="NavbarItem"
                @click="$router.push('/UploadPage')">
                <label>Upload Data</label>
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
        background-color: var(--colors-middle-blue);
    }
    .Navbar{
        display: flex;
    }
    .NavbarItem {
        margin: 10px 5px 20px 25px;
        padding: 5px;
        border: solid 1px var(--colors-middle-blue);
        border-radius: 10px;
        color: white;
        background-color: var(--colors-light-blue);
    }
        .NavbarItem label {
            margin: 10px;
            user-select: none;
        }
        .NavbarItem:hover {
            background-color: var(--colors-dark-blue);
        }

</style>