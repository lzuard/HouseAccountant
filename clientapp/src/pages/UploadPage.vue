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
        <h1>Inside content</h1>
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

export default{
    data(){
        return {
            files: []
        }
    },
    methods:{
        updateFiles(newFiles){
            this.files = newFiles
            console.log("files count: "+this.files.length)
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