/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable no-unused-vars */
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
              type="string"
              v-model="this.currentCity.name"
              label="City name *"
              hint="City name"
              lazy-rules
              :rules="[ val => val && val.length > 0 || 'Please type something']"
            />

            <q-input
              filled
              type="string"
              v-model="this.currentCity.description"
              label="City description *"
              hint="City description"
              lazy-rules
              :rules="[ val => val && val.length > 0 || 'Please type something']"
            />

            <!-- <q-toggle v-model="accept" label="I accept the license and terms" /> -->

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
import { Component, Prop, /* Watch , */ Vue /* , Emit */ } from 'vue-property-decorator';

import { cityService } from '../services/cityService';
import { City } from '../models/models';

@Component({
  // components: { CityDetail }
})
export default class CityEdit extends Vue {
  // addingCity = false;
  // currentCity: City || null = null;
  // addingCity = false;
  // currentCity: City || null = null;
  // public currentCity?: City;
  // @Prop()
  private currentCity: [] = [];

  // https://medium.com/@toastui/developing-vue-components-with-typescript-18357ae7f297
  // https://www.digitalocean.com/community/tutorials/vuejs-typescript-class-components
  // public cityToEdit!: City;// | null = null;
  // @Prop({ default: ({}), required: true })
  // public cityToEdit: City;
  @Prop({ required: true })
  public cityId!: number;

  async created() {
    // this.currentCity = null;
     await this.getCity(this.cityId);
  }

  async getCity(cityId: number) {
    // this.currentCity = null;
    await cityService.getCity(cityId)
      .then((response) => {
        this.currentCity = response.data;
        // eslint-disable-next-line no-console
        console.log(response.data);
      })
      .catch((e) => {
        // eslint-disable-next-line no-console
        console.log(e);
      });
  }

  // data() {
  //   return {
  //     currentCity: { ...this.cityToEdit },
  //   };
  // }

  // @Watch('currentCity')
  // onCityChanged(value: string, oldValue: string) {
  //   this.currentCity = this.cloneIt();
  // }

  // cloneIt() {
  //   // return Object.assign({}, this.currentCity);
  //   return { ...this.currentCity };
  // }

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  // eslint-disable-next-line no-unused-vars
  // @Emit('cityChanged') emitRefresh(mode: string, city: City) {
  //   this.clear();
  // }

  // @Emit('unselect') clear() {
  //   this.currentCity = null;
  // }

  public onSubmit() {
    this.$q.notify({
      color: 'green-4',
      textColor: 'white',
      icon: 'cloud_done',
      message: 'Submitted',
    });
  }

  public onReset() {
    this.currentCity.name = '';
    this.currentCity.description = '';
  }
}
</script>
