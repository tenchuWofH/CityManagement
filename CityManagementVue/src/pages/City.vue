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
// import { CityList } from 'components/City/CityList.vue';
import CityList from 'components/City/CityList.vue';

@Component({
  components: {
    // CityNew: () => import('@/components/City/CityNew.vue'),
    // CityList: () => import('@/components/City/CityList.vue'),
    // CityNew: () => import('../../components/City/CityNew.vue'),
    // CityList: () => import('../../components/City/CityList.vue'),
    CityList,
  },
})
export default class City extends Vue {
  showDialog = false;

  openCityNew() {
    this.showDialog = true;
  }
}
</script>
