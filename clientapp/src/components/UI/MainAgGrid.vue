<template>
    <div id="main-grid-container">
        <ag-grid-vue style="height: 500px"
                     class="ag-theme-quartz-dark"
                     :gridOptions="gridOptions">
        </ag-grid-vue>
    </div>
</template>

<script>
    import { ref } from 'vue';
    import "ag-grid-community/styles/ag-grid.css"; // Core CSS
    import "ag-grid-community/styles/ag-theme-quartz.css";  //Theme
    import { AgGridVue } from "ag-grid-vue3"; // Vue Grid Logic

    export default {
        name: "main-ag-grid",
        components: {
            AgGridVue, // Add AG Grid Vue3 component
        },
        setup() {
            const rowData = ref([
                {column1: "cell 1-1", column2: "cell 1-2"},
                {column1: "cell 2-2", column2: "cell 2-2"}
            ])
            const colDefs = ref([
                {field: "column1"},
                {field: "column2"}
            ])
            const gridOptions = ref({
                defaultColDef:{
                    sortable: true,
                    filter: true,
                 },
                 columnDefs: colDefs.value,
                 rowData: rowData.value,
            })
            return {
                gridOptions
            }

        },
    }
</script>

<style scoped>
    h1 {
        color: white;
    }
    #main-grid-container{
        margin: 40px;
    }
    .ag-theme-quartz-dark {
        --ag-background-color: #181818;
        --ag-header-background-color: #286dbd;
    }
</style>