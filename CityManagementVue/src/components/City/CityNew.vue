<template>
  <!-- <q-page padding>
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

            <q-toggle v-model="this.currentCity.isCapital" label="Capital?" />

            <div>
              <q-btn label="Submit" type="submit" color="primary"/>
              <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
            </div>
          </q-form>

        </div>
      </div>
  </q-page> -->
  <!-- <q-modal v-model="opened" :content-css="{minWidth: '80vw', minHeight: '80vh'}"> -->
  <q-modal v-model="showDialog" :content-css="{minWidth: '80vw', minHeight: '80vh'}">
  <q-modal-layout>
    <q-toolbar slot="header">
      <q-btn
        flat
        round
        dense
        v-close-overlay
        icon="keyboard_arrow_left"
      />
      <q-toolbar-title>
        Header
      </q-toolbar-title>
    </q-toolbar>

    <q-toolbar slot="header">
      <!-- <q-search inverted v-model="search" color="none" /> -->
    </q-toolbar>

    <q-toolbar slot="footer">
      <q-toolbar-title>
        Footer
      </q-toolbar-title>
    </q-toolbar>

    <div class="layout-padding">
      <h1>Modal</h1>

      <q-btn
        color="primary"
        v-close-overlay
        label="Close"
      />

      <p>This is a Modal presenting a Layout.</p>
    </div>
  </q-modal-layout>
</q-modal>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
// import { Q }

@Component
export default class CityNew extends Vue {
  showDialog: false|undefined;
}
</script>
