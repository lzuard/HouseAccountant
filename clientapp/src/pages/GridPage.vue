<template>
    <button @click="getData">
        Get data
    </button>
    <input type="file" @change="onFileChange" />
    <button @click="uploadData">
        Send data
    </button>
    <main-ag-grid />
</template>

<script>
    import axios from 'axios'

    export default {
        data() {
            return {
                headerRow: {id:''},
                dataRows: {id: ''},
                selectedFile: null
            }
        },
        methods: {
            onFileChange(e){
                this.selectedFile = e.target.files[0];
            },
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
            uploadData() {
                try{
/*                    if (this.SelectedFile == null){ 
                        return
                    }*/

                    console.log("uploadData")
                    let formData = new FormData();
                    formData.append('file', this.selectedFile);

                    const url = process.env.VUE_APP_ROOT_API + process.env.VUE_APP_GRID_API
                    axios.post(url, formData, {
                        headers: {
                            'Content-Type': 'multiplatform/form-data'
                        }
                    })
                    }
                catch(e){
                    console.log("Error "+ e)
                }
            }
            
        }
    }

</script>

<style scoped>
    h1{
        color: white;
    }
</style>