<template>
  <div>
    <h2 class="text-xl font-bold mb-4">Search Results</h2>
    <table class="min-w-full border border-gray-300 text-sm">
      <thead class="bg-gray-100">
        <tr>
          <th class="p-2 border">Search Engine</th>
          <th class="p-2 border">Search Phrase</th>
          <th class="p-2 border">URL</th>
          <th class="p-2 border">Formatted Output</th>
          <th class="p-2 border">Count</th>
          <th class="p-2 border">Date</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(result, index) in results" :key="index">
          <td class="p-2 border">{{ result.searchEngine }}</td>
          <td class="p-2 border">{{ result.searchPhrase }}</td>
          <td class="p-2 border">
            <a :href="result.url" target="_blank" class="text-blue-600 underline">
              {{ result.url }}
            </a>
          </td>
          <td class="p-2 border">{{ result.formattedOutput }}</td>
          <td class="p-2 border">{{ result.count }}</td>
          <td class="p-2 border">{{ result.date }}</td>
        </tr>
      </tbody>
    </table>

    <div v-if="loading" class="mt-2 text-gray-600">Loading...</div>
    <div v-if="error" class="mt-2 text-red-500">Failed to load results: {{ error }}</div>
  </div>
</template>

<script>
export default {
  name: 'SearchResultsTable',
  data() {
    return {
      results: [],
      loading: false,
      error: null
    }
  },
  mounted() {
    this.fetchResults()
  },
  methods: {
    async fetchResults() {
      this.loading = true
      try {
        const response = await fetch('https://localhost:7197/api/search/DailyHistory')
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
