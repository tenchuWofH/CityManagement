/* TODO: ajustar colunas de edit e delete */

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
          Cities
        </q-toolbar-title>

        <q-btn
          flat
          dense
          round
          icon="add"
          @click="openCityNew()"
        />

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

              <q-td key="actions" :props="props">
                <q-btn
                  flat
                  dense
                  round
                  icon="edit"
                  aria-label="Edit"
                  @click="editCity(props.row)"
                />
                <!-- <q-btn
                  flat
                  dense
                  round
                  icon="edit"
                  aria-label="Edit"
                  type="a"
                  @click="$router.replace('/cityEdit/'+props.row.id)"
                /> -->
                <q-btn
                  flat
                  dense
                  round
                  icon="delete"
                  aria-label="Delete"
                  @click="deleteCity(props.row)"
                />
              </q-td>

            </q-tr>
          </template>
        </q-table>
      </div>
      <CityNew />
    </q-page-container>

  </q-layout>
</template>

<script lang="ts">
// import Vue from 'vue';
// import { Component, Prop, Watch } from 'vue-property-decorator';
import { Component/* , Prop */, Vue } from 'vue-property-decorator';

// import CityDetail from './CityDetail.vue';
import { CityNew } from '../components/CityNew';
import { cityService } from '../services/cityService';
import { City } from '../models/models';

@Component({
  components: { CityNew },
})
export default class CityList extends Vue {
  // @Prop({ default: {} })
  // public selectedCity: City|null = null;

  // @Prop({ default: [] })
  public cities: City[] = [];

  // private columns: any[] = [];
  // @Prop({ default: [] })
  public columns: unknown[] = [
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

  async created() {
    await this.getCities();
  }

  async getCities() {
    // this.cities = [];
    // this.selectedCity = null;
    // return cityService.getCities().then((response) => (this.cities = response.data));
    await cityService.getCities()
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

  // https://codepen.io/mickey58/pen/eYYVqWv (Quasar QTable: Editing with QPopupEdits and QButtons to add/delete/update rows)
  // https://forum.quasar-framework.org/topic/381/solved-action-button-in-datatable/6
  editCity(city: City) {
    // // this.editedIndex = this.cities.indexOf(city);
    // // this.editedItem = Object.assign({}, city);
    // // this.show_dialog = true;
    // this.onSelect(city);
    // this.$router.push({ name: 'editCity', params: { cityId: this.selectedCity.cityId } });
    // // this.$router.push({ name: 'editCity', params: { cityToEdit: this.selectedCity } });

    const id = city.cityId.toString();
    this.$router.push({ name: 'editCity', params: { cityId: id } });
  }

  deleteCity(city: City) {
    const index = this.cities.indexOf(city);
    // eslint-disable-next-line no-alert
    // eslint-disable-next-line no-unused-expressions
    // eslint-disable-next-line no-restricted-globals
    // confirm('Are you sure you want to delete this City?') && this.cities.splice(index, 1);
    // eslint-disable-next-line no-alert
    if (confirm('Are you sure you want to delete this City?')) {
      this.cities.splice(index, 1);
    }
  }

  openCityNew() {
    this.showDialog = true;
  }

  // onSelect(city: City) {
  //   this.selectedCity = city;
  // }

  // unselect() {
  //   // this.addingCity = false;
  //   this.selectedCity = null;
  // }
}
</script>
