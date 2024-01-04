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
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
                { Date: "12.12.2023", Time: "11:05", Card: "Platinum", Type: "Grocery", Amount: "10000", Description: "Perekrestok" },
            ])
            const colDefs = ref([
                { field: "Date" },
                { field: "Time" },
                { field: "Card" },
                { field: "Type" },
                { field: "Amount" },
                { field: "Description" },


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
        --ag-background-color: var(--color-app-backround);
        --ag-header-background-color: var(--colors-middle-blue);
    }
</style>