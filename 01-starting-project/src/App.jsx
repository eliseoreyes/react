import Header from './components/Header/Header.jsx';
import TabButton from './components/CoreConcept/TabButton.jsx';
import CoreConcepts from './components/CoreConcept/CoreConcepts.jsx';
import Examples from './components/CoreConcept/Examples.jsx';

function App() {

  return (
    <>
      <Header></Header>
      <main>
       <CoreConcepts></CoreConcepts>
       <Examples></Examples>
      </main>
    </>
  );
}

export default App;
