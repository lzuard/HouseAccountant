<template>
    <div class="main">
        <div 
            class="dnd_container"
            @dragover="dragover"
            @dragleave="dragleave"
            @drop="drop"
            :style="isDragging && 'background-color: var(--blue-3)'"
        >
            <input
                type="file"
                multiple
                name="file"
                id="file_input"
                class="hidden_input"
                @change="onChange"
                ref="file"
                accept=".csv, .xls, .xlsx, .xlsb, .xlsm"
            />
            <label for="file_input" class="file-label">
                <div v-if="isDragging">Отпустите, чтобы загрузить файлы</div>
                <div v-else>Перетащите файлы сюда или <u>нажмите</u>, чтобы выбрать</div>
            </label>
            <div class="items_container" v-if="files.length">
                <div v-for="file in files" :key="file.name" class="file_item">
                    <main-button
                        class="remove_button"
                        @click="remove(files.indexOf(file))"
                    >
                        <b>×</b>
                    </main-button>
                    <img src="@/assets/file-icon.png" width="40px" height="40px"/>
                    <div>
                        <p>{{file.name}} - {{Math.round(file.size / 1000) + " kb"}}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default{
    name:"drop-file",
    data(){
        return{
            isDragging: false,
            files: [],
        }
    },
    methods:{
        onChange(){
            var droped_file_list = Array.from(this.$refs.file.files)
            var files_to_upload = []
            var bad_files = []
            droped_file_list.forEach(item => {
                if (["csv", "xlsx", "xlsx", "xlsm", "xlsb"].includes(item.name.substring(item.name.lastIndexOf('.')+1)))
                    files_to_upload.push(item)
                else
                    bad_files.push(item)
            });
            if (bad_files.length)
                alert(`Вы пытаетесь загрузить файлы неверного формата (Допустимо: .csv, .xls, .xlsx, .xlsm, .xlsb).\n\nФайлы, которые не были загружены:\n${bad_files.map(item => item.name).join("\n")}`)
            this.files.push(...files_to_upload)
            this.$emit('filesUpdated', this.files)
        },
        dragover(e){
            e.preventDefault()
            this.isDragging = true
        },
        dragleave(){
            this.isDragging=false
        },
        drop(e){
            e.preventDefault()
            this.$refs.file.files = e.dataTransfer.files
            this.onChange()
            this.isDragging = false
        },
        remove(i){
            this.files.splice(i,1)
        }

    }
}
</script>

<style>
 .main{
    display: flex;
    flex-grow: 1;
    align-items: center;
    justify-content: center;
    text-align: center;
    margin: 10px;
 }
 .dnd_container{
    padding: 4rem;
    background-color: var(--blue-3);
    border-radius: 30px;
    width: 100%;
 }
 .hidden_input{
    opacity: 0;
    overflow: hidden;
    position: absolute;
    width: 1px;
    height: 1px;
 }
 .file-label{
    font-size: 20px;
    display: block;
    cursor: pointer;
 }
 .items_container{
    display: block;
    margin-top: 2rem;
 }
 .file_item {
    display: flex;
    margin-left: 5px;
    align-items: center;
 }
 .file_item p{
    margin-left: 10px;
    margin-right: 10px;
    text-align: left;
 }

</style>