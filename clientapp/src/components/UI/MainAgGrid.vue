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
        props: {
            rowData: Object,
            header: Object
        },
        setup(props) {

            try{
                console.log(props.rowData)
            console.log(props.header)
            let columnDefs = Object.keys(props.header).map(key => ({field: key}))
            let rowData = Object.keys(props.rowData).reduce((rows, key) =>{
                console.log("inside")
                console.log(Object.keys(props.rowData))
                console.log(props.rowData)
                props.rowdData[key].foreaach((value, i) => {
                    rows[i] = rows[i] || {};
                    rows[i][key] = value;
                })
                return rows;
            }, []);

            const gridOptions = ref({
                defaultColDef:{
                    sortable: true,
                    filter: true,
                 },
                 columnDefs: columnDefs,
                 rowData: rowData,
            })
            return {
                gridOptions
            }
            }
            catch(error){
                console.log(error);
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
        --ag-header-background-color: var(--color-blue-middle);
    }
</style>