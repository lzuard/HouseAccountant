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
    }
    #navbar-container {
        display: flex;
        justify-content: space-between;
        background-color: var(--color-blue-middle);
    }
    .Navbar{
        display: flex;
    }
    .NavbarItem {
        margin: 10px 5px 20px 25px;
        padding: 5px;
        border: solid 1px var(--color-blue-middle);
        border-radius: 10px;
        color: white;
        background-color: var(--color-blue-light);
    }
        .NavbarItem label {
            margin: 10px;
            user-select: none;
        }
        .NavbarItem:hover {
            background-color: var(--color-blue-dark);
        }

</style>