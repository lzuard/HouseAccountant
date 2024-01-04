<template>
    <button @click="getData"
            >
    Get data
    </button>
    <button
            @click="uploadFile"
            >
    Upload file
    </button>
    <main-ag-grid />
</template>

<script>
    import axios from 'axios'

    export default {
        data() {
            return {
                headerRow: {id:''},
                dataRows: {id: ''}
            }
        },
        methods: {
            async getData() {
                console.log("getData")
                await this.fetchData()
            },
            async fetchData() {
                try {
                    const url = process.env.VUE_APP_ROOT_API + process.env.VUE_APP_GRID_API
                    const responce = await axios.get(url, {
                        params: {
                            _id: 1
                        }
                    })
                    console.log("responce is"+responce.data)
                }
                catch (e) {
                    console.log("Error: " + e)
                }
            },
            uploadFile() {
                console.log("uploadData")
            }
        }
    }

</script>

<style scoped>
    h1{
        color: white;
    }
</style>