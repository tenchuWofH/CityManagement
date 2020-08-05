/* eslint-disable no-console */
/* eslint-disable no-console */
/* eslint-disable no-return-assign */
/* eslint-disable no-return-assign */
<template>
  <q-layout view="hHh lpR fFf">

    <q-header elevated class="bg-primary text-white">
      <q-toolbar>
        <q-toolbar-title>
          <q-avatar>
            <img src="https://cdn.quasar.dev/logo/svg/quasar-logo.svg">
          </q-avatar>
          Title
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />

      <div class="q-pa-md">
        <q-table
          title="Cities"
          :data="cities"
          :columns="columns"
          row-key="name"
        >
          <template v-slot:body="props">
            <q-tr :props="props">
              <q-td key="name" :props="props">
                {{ props.row.name }}
                <q-popup-edit v-model="props.row.name">
                  <q-input v-model="props.row.name" dense autofocus counter />
                </q-popup-edit>
              </q-td>

              <q-td key="description" :props="props">
                {{ props.row.description }}
                <q-popup-edit
                  buttons
                  v-model="props.row.description"
                >
                  <q-input
                    type="textarea"
                    v-model="props.row.description"
                    autofocus
                    counter
                    @keyup.enter.stop
                  />
                </q-popup-edit>
              </q-td>
            </q-tr>
          </template>
        </q-table>
      </div>
    </q-page-container>

  </q-layout>
</template>

<script lang="ts">
// import Vue from 'vue';
// import { Component, Prop, Watch } from 'vue-property-decorator';
import { Component, Vue } from 'vue-property-decorator';

// import CityDetail from './CityDetail.vue';
import { cityService } from '../services/cityService';
import { City } from '../models/models';

@Component({
  // components: { CityDetail }
})
export default class CityList extends Vue {
  // addingCity = false;
  selectedCity: City | null = null;

  cities: City[] = [];

  // private columns: any[] = [];

  columns: unknown[] = [
    {
      name: 'name',
      required: true,
      label: 'Name',
      align: 'left',
      field: 'name',//row => row.name,
      // format: val => `${val}`,
      sortable: true,
    },
    { name: 'description', align: 'center', label: 'Description', field: 'description', sortable: true }
  ];

  // cities(){
  //   return _cities;
  // }

  // columns(){
  //   return _columns;
  // }

  // data(){
  //   columns: [
  //     {
  //       name: 'name',
  //       required: true,
  //       label: 'Name',
  //       align: 'left',
  //       field: 'name',//row => row.name,
  //       format: val => `${val}`,
  //       sortable: true
  //     },
  //     { name: 'description', align: 'center', label: 'Description', field: 'description', sortable: true }
  //   ],
  // }

  created() {
    this.getCities();
  }
  // deleteCity(city: City) {
  //   return cityService.deleteCity(city).then(() => {
  //     this.cities = this.cities.filter(h => h !== city);
  //     if (this.selectedCity === city) {
  //       this.selectedCity = null;
  //     }
  //   });
  // }
  // enableAddMode() {
  //   this.addingCity = true;
  //   this.selectedCity = null;
  // }

  getCities() {
    // this.cities = [];
    this.selectedCity = null;
    // return cityService.getCities().then((response) => (this.cities = response.data));
    cityService.getCities()
      .then((response) => {
        this.cities = response.data;
        // eslint-disable-next-line no-console
        console.log(response.data);
      })
      .catch((e) => {
        // eslint-disable-next-line no-console
        console.log(e);
      });
  }
  // cityChanged(mode: string, city: City) {
  //   console.log('city changed', city);
  //   if (mode === 'add') {
  //     cityService.addCity(city).then(() => this.cities.push(city));
  //   } else {
  //     cityService.updateCity(city).then(() => {
  //       let index = this.cities.findIndex(h => city.id === h.id);
  //       this.cities.splice(index, 1, city);
  //     });
  //   }
  // }

  onSelect(city: City) {
    this.selectedCity = city;
  }

  unselect() {
    this.addingCity = false;
    this.selectedCity = null;
  }
}
</script>
