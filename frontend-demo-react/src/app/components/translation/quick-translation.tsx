import './quick-translation.css';
import { FormEvent, useEffect, useState } from "react";
import { useDebounce } from "../../hooks/debounce";
import { useQTAPI } from "../../infrastructure/api/usecases/quick-translation";
import { LanguageSelector } from "./language-selector/language-selector"

export const QuickTranslation = () => {

  const [ fromLanguage, setFromLang   ] = useState("");
  const [ toLanguage  , setToLang     ] = useState("");
  const [ inputText   , setInputText  ] = useState("");
  const [ outputText  , setOutputText ] = useState("");

  const [ trigger     , setTrigger    ] = useState(false);

  const debouncedText = useDebounce(inputText);

  const fromProps = { direction: "from", selectCallback: setFromLang };
  const toProps   = { direction: "to", selectCallback: setToLang };


  const handleInput = (e: FormEvent<HTMLTextAreaElement>) => {
    setInputText(e.currentTarget.value);
    setTrigger(false);
  }


  const payload = {
    sourceLanguage: fromLanguage, 
    targetLanguage: toLanguage, 
    text: debouncedText
  };

  const { response, error } = useQTAPI(payload, trigger);


  useEffect(() => {

    setOutputText(response.text);
    setTrigger(false);

  }, [ response, error ]);

  useEffect(() => {

    setTrigger(true);

  }, [ debouncedText, fromLanguage, toLanguage ]);
  

  return (
    <div id="qt-root">
      <div id="qt-from-group" className="qt-group">
        <LanguageSelector {... fromProps}/>
        <textarea placeholder="Enter text" onChange={handleInput}/>
      </div>
      <div id="qt-to-group" className="qt-group">
        <LanguageSelector {... toProps}/>
        <textarea readOnly placeholder="Translation here . . ." value={outputText}/>
      </div>
    </div>
  );

}