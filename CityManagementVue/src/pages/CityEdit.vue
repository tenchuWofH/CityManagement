/* eslint-disable max-len */
/* eslint-disable no-console */
/* eslint-disable no-return-assign */
<template>
  <q-layout view="hHh lpR fFf">

    <q-header elevated class="bg-primary text-white">
      <q-toolbar>
        <q-toolbar-title>
          <q-avatar>
            <img src="https://cdn.quasar.dev/logo/svg/quasar-logo.svg">
          </q-avatar>
          Edit City
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />

      <div class="q-pa-md">
        <div class="q-pa-md" style="max-width: 400px">

          <q-form
            @submit="onSubmit"
            @reset="onReset"
            class="q-gutter-md"
          >
            <q-input
              filled
              v-model="name"
              label="Your name *"
              hint="Name and surname"
              lazy-rules
              :rules="[ val => val && val.length > 0 || 'Please type something']"
            />

            <q-input
              filled
              type="number"
              v-model="age"
              label="Your age *"
              lazy-rules
              :rules="[
                val => val !== null && val !== '' || 'Please type your age',
                val => val > 0 && val < 100 || 'Please type a real age'
              ]"
            />

            <q-toggle v-model="accept" label="I accept the license and terms" />

            <div>
              <q-btn label="Submit" type="submit" color="primary"/>
              <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
            </div>
          </q-form>

        </div>
      </div>


    </q-page-container>

  </q-layout>
</template>

<script lang="ts">
// import Vue from 'vue';
// import { Component, Prop, Watch } from 'vue-property-decorator';
import { Component, Vue } from 'vue-property-decorator';
import { Router } from 'vue-router';


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
      name: 'actions',
      align: 'right',
      width: '5px',
      field: 'actions',
    },
    {
      name: 'name',
      required: true,
      label: 'Name',
      align: 'left',
      field: 'name', // row => row.name,
      // format: val => `${val}`,
      sortable: true,
      width: '50px',
    },
    {
      // eslint-disable-next-line comma-dangle
      name: 'description',
      align: 'left',
      label: 'Description',
      field: 'description',
      sortable: true,
      width: '200px',
    },
  ];

  created() {
    this.getCities();
  }

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

  // // https://codepen.io/mickey58/pen/eYYVqWv (Quasar QTable: Editing with QPopupEdits and QButtons to add/delete/update rows)
  // editCity(city: City) {
  //   // this.editedIndex = this.cities.indexOf(city);
  //   // this.editedItem = Object.assign({}, city);
  //   // this.show_dialog = true;
    
  // }

  // deleteCity(city: City) {
  //   const index = this.cities.indexOf(city);
  //     confirm('Are you sure you want to delete this City?') && this.cities.splice(index, 1);
  // }

  onSelect(city: City) {
    this.selectedCity = city;
  }

  unselect() {
    // this.addingCity = false;
    this.selectedCity = null;
  }
}
</script>
