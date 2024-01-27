<template>
    <content-box
        headerText="Files to upload" 
        :isShowContent="true"
        :isHidable="true"
        :defaultIsShowContent="true"
        >
        <div id="files_container">
            <div id="list_of_files">
                <p>Uploaded files:</p>
                <ul v-for="file in files" :key="file.name">
                    <li>{{file.name}}</li>
                </ul>
                <main-button 
                    @click="uploadFiles" 
                    :isActive="files.length"
                    >
                    Upload
                </main-button>
            </div>
            <div id="dnd_zone">
                <drop-file @filesUpdated="updateFiles"/>
            </div>
        </div>
    </content-box>
    <content-box 
        headerText="Preview" 
        :isShowContent="true"
        :isHidable="true"
        >
        <main-ag-grid :header="header" :rowData="rowData"/>
    </content-box>
    <content-box 
        headerText="Confirm" 
        :isShowContent="true"
        :isHidable="true"
        >
        <h1>Inside content</h1>
    </content-box>
</template>

<script>
import axios from 'axios';


export default{
    data() {
        return {
            files: [],
            previewHeader: [],
            previewRows:[]
        };
    },
    methods: {
        updateFiles(newFiles) {
            this.files = newFiles;
            console.log("files count: " + this.files.length);
        },
        uploadFiles() {
            console.log("start upload");
            let file = this.files[0];
            let formData = new FormData();
            formData.append('file', file);

            axios.post(`${process.env.VUE_APP_ROOT_API+process.env.VUE_APP_UPLOAD_API}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(responce => {
                console.log(responce)
                this.header = Object.keys(responce.data);
                this.rowData = responce.data
                console.log(this.header)
                console.log(this.rowData)
            }).catch(error => {
                console.log(error);
            });

        }
    }
}

</script>

<style scoped>
#files_container{
    display: flex;
}
#list_of_files{
    width: 50%;
}
#dnd_zone{
    width: 50%;
}
</style>