<template>
  <div class="search-container">
    <h2 class="heading">📊 Weekly Search History</h2>

    <div v-if="loading" class="status-text">Loading weekly results...</div>
    <div v-if="error" class="error-text">❌ Failed to load: {{ error }}</div>

    <table class="results-table" v-if="results.length">
      <thead>
        <tr>
          <th>Search Engine</th>
          <th>Search Phrase</th>
          <th>URL</th>
          <th>Week Start</th>
          <th>Count</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(entry, index) in results" :key="index">
          <td>{{ entry.searchEngine }}</td>
          <td>{{ entry.searchPhrase }}</td>
          <td>
            <a :href="entry.url" target="_blank" class="link">{{ entry.url }}</a>
          </td>
          <td>{{ entry.weekStart }}</td>
          <td>{{ entry.count }}</td>
        </tr>
      </tbody>
    </table>

    <div v-if="!loading && !results.length" class="status-text">No weekly data found.</div>
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

          if (!response.ok) throw new Error(`HTTP ${response.status}`)
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
  .search-container {
    width: 100%;
    min-height: 800px;
    max-width: 800px;
    margin: 2rem auto;
    padding: 1.5rem;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    font-family: 'Segoe UI', sans-serif;
    color: #333;
  }

  .heading {
    font-size: 1.5rem;
    font-weight: bold;
    margin-bottom: 1.5rem;
  }

  .status-text {
    font-size: 1rem;
    color: #555;
    margin: 1rem 0;
  }

  .error-text {
    color: red;
    font-weight: 600;
  }

  .results-table {
    width: 100%;
    border-collapse: collapse;
    font-size: 0.95rem;
    margin-top: 1rem;
  }

    .results-table th,
    .results-table td {
      padding: 0.75rem;
      border: 1px solid #ccc;
      text-align: left;
    }

    .results-table th {
      background-color: #f4f4f4;
      font-weight: 600;
    }

  .link {
    color: #2e86de;
    text-decoration: underline;
  }

    .link:hover {
      color: #2167b6;
    }
</style>
