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
                    :isActive="files.length > 0"
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
        <main-ag-grid :columnDefs="previewHeader" :rowData="previewRows"/>
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
                let keys = Object.keys(responce.data)
                this.previewHeader = keys.map(item => ({field: item}))
                console.log(this.previewHeader)
                this.previewRows = responce.data[keys[0]].map((_,i) => {
                    return keys.reduce((obj, key) => {
                        obj[key] = responce.data[key][i];
                        return obj;
                    }, {});
                })
                console.log(this.previewRows)
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