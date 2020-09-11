<!-- TODO: resize Dialog -->
<template>
  <q-page padding>
    <q-layout view="hHh lpR fFf">

      <q-header elevated class="bg-primary text-white">
        <q-toolbar>
          <q-toolbar-title>
            <q-avatar>
              <img src="https://cdn.quasar.dev/logo/svg/quasar-logo.svg">
            </q-avatar>
            New City
          </q-toolbar-title>
        </q-toolbar>
      </q-header>

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
              v-model="newCity.name"
              label="City name *"
              hint="City name"
              lazy-rules
              :rules="[ val => val && val.length > 0 || 'Please type something']"
            />

            <q-input
              filled
              type="string"
              v-model="newCity.description"
              label="City description *"
              hint="City description"
              lazy-rules
              :rules="[ val => val && val.length > 0 || 'Please type something']"
            />

            <q-toggle v-model="newCity.isCapital" label="Capital?" />

            <div>
              <q-btn label="Submit" type="submit" color="primary"/>
              <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
            </div>
          </q-form>

        </div>
      </div>
    </q-layout>
  </q-page>

</template>

<script lang="ts">
// import City from 'src/pages/City.vue';
import { Vue, Component } from 'vue-property-decorator';
// import { QModal } from 'quasar';
import { City } from '../../models/models';
// import cityService from '../../services/CityDataService';

@Component({
  // components: {
  //   QModal,
  // },
})
export default class CityNew extends Vue {
  // eslint-disable-next-line @typescript-eslint/no-inferrable-types
  // showDialog: boolean = false;
  private newCity: City = {
    cityId: -1, name: '', description: '', isCapital: false, pointsOfInterest: [{ pointOfInterestId: -1, name: '', description: '' }],
  };

  /**
   *
   */
  // constructor() {
  //   super();
  //   this.newCity = {
  //     cityId: -1, name: '', description: '', isCapital: false, pointsOfInterest: [{ pointOfInterestId: -1, name: '', description: '' }],
  //   };
  // }

  // created() {
  //   this.newCity = new City(); // { name: '', description: '', isCapital: false };
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
    this.newCity.name = '';
    this.newCity.description = '';
  }
}
</script>
