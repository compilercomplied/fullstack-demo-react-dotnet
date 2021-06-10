// import logo from '../assets/logo.svg';
import './App.css';
import { ToastBucket } from './components/notification/toast';
import { QuickTranslation } from './components/translation/quick-translation';
import { ToastProvider } from './contexts/toast';

function App() {
  return ( 
    <div id="app">
      <ToastProvider>
        <QuickTranslation/> 
        <ToastBucket/>
      </ToastProvider>
    </div>
  );
}

export default App;
