<template>
    <content-box
        headerText="Загрузка файлов" 
        :isShowContent="true"
        :isHidable="true"
        :defaultIsShowContent="true"
        >
        <div id="files_container">
            <div id="list_of_files">
                <p>Загружаемые файлы:</p>
                <ul v-for="file in files" :key="file.name">
                    <li>{{file.name}}</li>
                </ul>
                <main-button 
                    @click="uploadFiles" 
                    :isActive="files.length > 0"
                    >
                    Загрузить
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
        },
        uploadFiles() {
            let formData = new FormData();

            this.files.forEach(file => {
                formData.append('files', file, file.name)
            })

            axios.post(`${process.env.VUE_APP_ROOT_API+process.env.VUE_APP_UPLOAD_API}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(responce => {
                this.previewHeader = responce.data["header"].map(value => ({field: value}));
                this.previewRows = responce.data["data"];
            }).catch(error => {
                console.log("Error ocured");
                console.log(error);
            })
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