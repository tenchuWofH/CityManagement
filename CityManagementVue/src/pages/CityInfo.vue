/* eslint-disable linebreak-style */
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
        <q-popup-edit
          buttons
          style="width: 300px; height: 400px;"
          v-model="showDialog"
        >
          <CityNew

          >
          </CityNew>
        </q-popup-edit>

      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />

      <!-- <CityNew /> -->
      <CityList />
    </q-page-container>

  </q-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
// TODO: mudar para dynamic import
import CityList from 'components/City/CityList.vue';
import CityNew from 'components/City/CityNew.vue';
import CityEdit from 'components/City/CityEdit.vue';

@Component({
  components: {
    // CityNew: () => import('@/components/City/CityNew.vue'),
    // CityList: () => import('@/components/City/CityList.vue'),
    // CityNew: () => import('../../components/City/CityNew.vue'),
    // CityList: () => import('../../components/City/CityList.vue'),
    // CityEdit: () => import('./components/City/CityEdit.vue'),
    CityList,
    CityNew,
    CityEdit,
  },
})
export default class CityInfo extends Vue {
  showDialog = false;

  openCityNew() {
    this.showDialog = true;
  }
}
</script>
