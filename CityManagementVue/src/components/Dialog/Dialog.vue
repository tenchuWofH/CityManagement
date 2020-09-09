<template>
  <q-dialog
    :value="showDialog"
    @input="$emit('update:showDialog', $event)"
    :full-width="!$q.platform.is.desktop"
    :position="position"
    no-refocus
  >
    <slot></slot>
  </q-dialog>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class Dialog extends Vue {
  @Prop()
  showDialog: unknown;

  @Prop()
  position: ''|undefined;

  get fullName(): string {
    return this.$q.platform.is.desktop ? 'top' : 'standard';
  }
}
</script>
