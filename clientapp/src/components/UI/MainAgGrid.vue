<template>
    <div id="main-grid-container">
        <ag-grid-vue style="height: 500px"
                     class="ag-theme-quartz-dark"
                     :rowData="rowData"
                     :columnDefs="columnDefs">
        </ag-grid-vue>
    </div>
</template>

<script>
    // import { ref } from 'vue';
    import "ag-grid-community/styles/ag-grid.css"; // Core CSS
    import "ag-grid-community/styles/ag-theme-quartz.css";  //Theme
    import { AgGridVue } from "ag-grid-vue3"; // Vue Grid Logic
import { ref } from "vue";

    export default {
        name: "main-ag-grid",
        components: {
            AgGridVue, // Add AG Grid Vue3 component
        },
        props: {
            rowData: ref([]),
            columnDefs: ref([])
        },
        // setup(props) {
        //     const gridOptions = ref({
        //         defaultColDef:{
        //             sortable: true,
        //             filter: true,
        //          },
        //          columnDefs: props.columnDefs,
        //          rowData: props.rowData,
        //     })
        //     return {
        //         gridOptions
        //     }
        // },
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
        --ag-background-color: var(--color-app-backround);
        --ag-header-background-color: var(--color-blue-middle);
    }
</style>