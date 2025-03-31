<template>
  <div>
    <h2 class="text-xl font-bold mb-4">Weekly Search History</h2>

    <table class="min-w-full border border-gray-300 text-sm">
      <thead class="bg-gray-100">
        <tr>
          <th class="p-2 border">Search Engine</th>
          <th class="p-2 border">Search Phrase</th>
          <th class="p-2 border">URL</th>
          <th class="p-2 border">Week Start</th>
          <th class="p-2 border">Count</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(entry, index) in results" :key="index">
          <td class="p-2 border">{{ entry.searchEngine }}</td>
          <td class="p-2 border">{{ entry.searchPhrase }}</td>
          <td class="p-2 border">
            <a :href="entry.url" target="_blank" class="text-blue-600 underline">
              {{ entry.url }}
            </a>
          </td>
          <td class="p-2 border">{{ entry.weekStart }}</td>
          <td class="p-2 border">{{ entry.count }}</td>
        </tr>
      </tbody>
    </table>

    <div v-if="loading" class="mt-2 text-gray-600">Loading...</div>
    <div v-if="error" class="mt-2 text-red-500">Failed to load weekly history: {{ error }}</div>
  </div>
</template>

<script>
export default {
  name: 'SearchHistoryWeekly',
  data() {
    return {
      results: [],
      loading: false,
      error: null
    }
  },
  mounted() {
    this.fetchWeeklyHistory()
  },
  methods: {
    async fetchWeeklyHistory() {
      this.loading = true
      try {
        const response = await fetch('https://localhost:7197/api/search/WeeklyHistory', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            phrase: '',
            engine: '',
            from: null,
            to: null
          })
        })

        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`)
        this.results = await response.json()
      } catch (err) {
        this.error = err.message
      } finally {
        this.loading = false
      }
    }
  }
}
</script>

<style scoped>
  table {
    border-collapse: collapse;
  }
</style>

