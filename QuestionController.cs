using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public bool m_democrat = false;
    public bool m_republican = false;

    public CrowdController m_crowdForThisQuestion;

    [ContextMenu("Test")]
    public void DemocratOption()
    {
        m_democrat = true;
        m_republican = false;
        m_crowdForThisQuestion.MoveCrowd(m_republican, m_democrat);
    }

    [ContextMenu("Test2")]
    public void RepublicanOption()
    {
        m_republican = true;
        m_democrat = false;
        m_crowdForThisQuestion.MoveCrowd(m_republican, m_democrat);
    }

}
