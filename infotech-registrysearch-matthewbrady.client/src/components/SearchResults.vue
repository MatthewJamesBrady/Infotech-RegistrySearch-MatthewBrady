<template>
  <div class="results-grid">
    <div v-if="loading" class="loading">Loading...</div>
    <div v-else-if="hasResults">
      <div class="card"  >
        <h4>{{ result.searchEngine }}</h4>
        <p><strong>Phrase:</strong> {{ result.searchPhrase }}</p>
        <p><strong>Count:</strong> {{ result.count }}</p>
        <p><strong>Search Engine:</strong> {{ result.searchEngine }}</p>
        <p><strong>Url:</strong> {{ result.url }}</p>
      </div>
    </div>
    <!--//<div v-else class="no-results">No results found.</div>-->
  </div>
</template>

<script>
  export default {
    name: 'SearchResults',
    props: {
      result : {
        type: Object,
         
      },
      loading: {
        type: Boolean,
        default: false
      }
    },
    computed: {
      hasResults() {
         return this.result  != null ;
      }
    }
  };
</script>

<style scoped>
  .results-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
    gap: 1.2rem;
    margin-top: 1rem;
  }

  .card {
    background-color: #ffffff;
    border: 1px solid #e0e0e0;
    border-radius: 8px;
    padding: 1rem;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.05);
    transition: transform 0.2s ease;
  }

    .card:hover {
      transform: scale(1.02);
    }

    .card h4 {
      margin: 0 0 0.5rem;
      font-size: 1.1rem;
      color: #2e86de;
    }

    .card p {
      margin: 0.3rem 0;
      font-size: 0.95rem;
    }

    .card a {
      display: block;
      margin-top: 0.5rem;
      color: #2e86de;
      text-decoration: underline;
      word-break: break-word;
    }

  .loading,
  .no-results {
    text-align: center;
    font-style: italic;
    color: #777;
    padding: 1rem;
  }
</style>
