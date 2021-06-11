import React from "react";
import { LanguageMaster } from "../../../domain/models/translation/language-master";
import { SetState } from "../../../extensions/react-wrap";

// --- constants ---------------------------------------------------------------
const availableLanguages: LanguageMaster[] = [
  { id: 1, code: "EN", displayname: "English" },
  { id: 2, code: "DE", displayname: "German"  },
  { id: 3, code: "FR", displayname: "French"  },
]

// --- helpers -----------------------------------------------------------------
const generateLangOptions = (lang: LanguageMaster) => 
  <option value={lang.code} key={lang.id}>{lang.displayname}</option>;


// --- component ---------------------------------------------------------------
type LanguageSelectorProps = {

  direction: string;
  selectCallback: SetState<string>;

}
export const LanguageSelector = (props: LanguageSelectorProps) => {

  const mapSelection = (e: React.FormEvent<HTMLSelectElement>) => {
    props.selectCallback(e.currentTarget.value);
  }


  return (

    <div className="ls-root">
      <select className="dropdown" onChange={mapSelection}>

        <option value={""}>{props.direction}</option>;

        { availableLanguages.map(generateLangOptions) } 

      </select>
    </div>

  );

}