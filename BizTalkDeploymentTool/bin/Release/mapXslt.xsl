<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:var="http://schemas.microsoft.com/BizTalk/2003/var" exclude-result-prefixes="msxsl var s0 userCSharp" version="1.0" xmlns:ns0="urn:com.workday/workersync" xmlns:s0="urn:com.workday.report/INT001_Worker_Changes" xmlns:userCSharp="http://schemas.microsoft.com/BizTalk/2003/userCSharp">
  <xsl:output omit-xml-declaration="yes" method="xml" version="1.0" />
  <xsl:template match="/">
    <xsl:apply-templates select="/s0:Report_Data" />
  </xsl:template>
  <xsl:template match="/s0:Report_Data">
    <ns0:Worker_Sync>
      <xsl:for-each select="s0:Report_Entry">
        <!--<xsl:if test ="not(count(s0:Termination_Primary[@s0:Descriptor = 'End Contingent Worker Contract > Voluntary > Convert to Employee']) > 0) 
                       and (s0:has_StepEnable_Completed/text() ='true' or s0:has_StepEnable_Completed/text() = '1')">-->
        <xsl:if test ="s0:has_StepEnable_Completed/text() ='true' or s0:has_StepEnable_Completed/text() = '1'">
          <xsl:choose>
            <xsl:when test ="count(s0:Termination_Primary[@s0:Descriptor = 'End Contingent Worker Contract > Voluntary > Convert to Employee']) > 0 and s0:Active_Status/text()!='1'">

            </xsl:when>
            <xsl:otherwise>
              <ns0:Worker>
                <ns0:Summary>
                  <ns0:Employee_ID>
                    <xsl:if test="s0:Employee_ID">
                      <xsl:value-of select="s0:Employee_ID/text()" />
                    </xsl:if>
                  </ns0:Employee_ID>
                </ns0:Summary>
                <ns0:Personal>
                  <ns0:Name_Data>
                    <ns0:First_Name>
                      <xsl:if test="s0:First_Name">
                        <xsl:value-of select="s0:First_Name/text()" />
                      </xsl:if>
                    </ns0:First_Name>
                    <xsl:if test="s0:Legal_Name/s0:Legal_FamilyNamePrefix">
                      <ns0:Middle_Name>
                        <xsl:value-of select="s0:Legal_Name/s0:Legal_FamilyNamePrefix/text()" />
                      </ns0:Middle_Name>
                    </xsl:if>
                    <xsl:if test="s0:Last_Name">
                      <ns0:Last_Name>
                        <xsl:value-of select="s0:Last_Name/text()" />
                      </ns0:Last_Name>
                    </xsl:if>
                    <xsl:if test="s0:MaidenLastName">
                      <ns0:Secondary_Last_Name>
                        <xsl:value-of select="s0:MaidenLastName/text()" />
                      </ns0:Secondary_Last_Name>
                    </xsl:if>
                    <xsl:if test="s0:Title">
                      <ns0:Title>
                        <xsl:value-of select="s0:Title/text()" />
                      </ns0:Title>
                    </xsl:if>
                    <xsl:if test="s0:Social_Suffix">
                      <ns0:Social_Suffix>
                        <xsl:value-of select="s0:Social_Suffix/text()" />
                      </ns0:Social_Suffix>
                    </xsl:if>
                  </ns0:Name_Data>
                  <xsl:if test="s0:Gender/s0:ID[@s0:type='Gender_Code']">
                    <ns0:Gender>
                      <xsl:value-of select="s0:Gender/s0:ID[@s0:type='Gender_Code']/text()" />
                    </ns0:Gender>
                  </xsl:if>
                  <xsl:for-each select="s0:Phone_Numbers">
                    <xsl:variable name ="Is_Public">
                      <xsl:choose>
                        <xsl:when test ="s0:Is_Public/text() = '1'">
                          <xsl:value-of select ="'true'"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select ="'false'"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:variable>
                    <xsl:variable name ="Is_Primary">
                      <xsl:choose>
                        <xsl:when test ="s0:Is_Primary/text() = '1'">
                          <xsl:value-of select ="'true'"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select ="'false'"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:variable>
                    <xsl:variable name ="Formatted_Phone_Number" select="s0:Phone_Number/text()"/>
                    <xsl:variable name ="International_Phone_Code" select="s0:Phone_Country_Code/text()"/>
                    <xsl:variable name ="Phone_Area_Code" select="s0:Phone_Area_Code/text()"/>
                    <xsl:variable name ="Phone_Number" select="s0:Phone_Number/text()"/>
                    <xsl:variable name ="Phone_Extension" select="s0:Phone_Extension/text()"/>

                    <xsl:variable name="Phone_Device_Type">
                      <xsl:value-of select ="s0:Phone_Type/s0:ID[@s0:type='Phone_Device_Type_ID']/text()"/>
                    </xsl:variable>
                    <xsl:for-each select="s0:Phone_Usage_Type">
                      <xsl:for-each select="s0:ID">
                        <xsl:if test ="./text() = 'WORK' and @s0:type='Communication_Usage_Type_ID'">
                          <ns0:Phone_Data>
                            <ns0:Phone_Type>
                              <xsl:value-of select="./text()" />
                            </ns0:Phone_Type>
                            <ns0:Phone_Device_Type>
                              <xsl:value-of select="$Phone_Device_Type" />
                            </ns0:Phone_Device_Type>
                            <ns0:Phone_Is_Public>
                              <xsl:value-of select ="$Is_Public"/>
                            </ns0:Phone_Is_Public>
                            <ns0:Is_Primary>
                              <xsl:value-of select ="$Is_Primary"/>
                            </ns0:Is_Primary>
                            <ns0:Formatted_Phone_Number>
                              <xsl:value-of select ="$Formatted_Phone_Number"/>
                            </ns0:Formatted_Phone_Number>
                            <ns0:International_Phone_Code>
                              <xsl:value-of select ="$International_Phone_Code"/>
                            </ns0:International_Phone_Code>
                            <ns0:Phone_Area_Code>
                              <xsl:value-of select ="$Phone_Area_Code"/>
                            </ns0:Phone_Area_Code>
                            <ns0:Phone_Number>
                              <xsl:value-of select ="$Phone_Number"/>
                            </ns0:Phone_Number>
                            <ns0:Phone_Extension>
                              <xsl:value-of select ="$Phone_Extension"/>
                            </ns0:Phone_Extension>
                          </ns0:Phone_Data>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
                  </xsl:for-each>
                  <xsl:for-each select="s0:Emails">
                    <xsl:variable name ="Is_Public">
                      <xsl:choose>
                        <xsl:when test ="s0:Is_Public/text() = '1'">
                          <xsl:value-of select ="'true'"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select ="'false'"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:variable>
                    <xsl:variable name ="Is_Primary">
                      <xsl:choose>
                        <xsl:when test ="s0:Is_Primary/text() = '1'">
                          <xsl:value-of select ="'true'"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select ="'false'"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:variable>
                    <xsl:variable name="Email_Address" select="s0:Email_Address/text()"/>
                    <xsl:for-each select="s0:Usage_Type">
                      <xsl:for-each select="s0:ID">
                        <xsl:if test ="./text()='WORK' and @s0:type='Communication_Usage_Type_ID'">
                          <ns0:Email_Data>
                            <ns0:Email_Type>
                              <xsl:value-of select="./text()" />
                            </ns0:Email_Type>
                            <ns0:Email_Is_Public>
                              <xsl:value-of select ="$Is_Public"/>
                            </ns0:Email_Is_Public>
                            <ns0:Is_Primary>
                              <xsl:value-of select ="$Is_Primary"/>
                            </ns0:Is_Primary>
                            <ns0:Email_Address>
                              <xsl:value-of select="$Email_Address" />
                            </ns0:Email_Address>
                          </ns0:Email_Data>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
                  </xsl:for-each>
                </ns0:Personal>
                <ns0:Status>
                  <ns0:Active>
                    <xsl:choose>
                      <xsl:when test ="s0:Active_Status/text() ='1'">
                        <xsl:value-of select ="'true'"/>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select ="'false'"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </ns0:Active>

                  <xsl:if test="s0:Hire_Date">
                    <ns0:Hire_Date>
                      <xsl:value-of select="s0:Hire_Date/text()" />
                    </ns0:Hire_Date>
                  </xsl:if>

                  <xsl:if test="s0:Original_Hire_Date">
                    <ns0:Original_Hire_Date>
                      <xsl:value-of select="s0:Original_Hire_Date/text()" />
                    </ns0:Original_Hire_Date>
                  </xsl:if>

                  <xsl:if test="s0:Termination_Date">
                    <ns0:Termination_Date>
                      <xsl:value-of select="s0:Termination_Date/text()" />
                    </ns0:Termination_Date>
                  </xsl:if>

                  <xsl:if test="s0:Last_Day_Of_Work">
                    <ns0:Termination_Last_Day_of_Work>
                      <xsl:value-of select="s0:Last_Day_Of_Work/text()" />
                    </ns0:Termination_Last_Day_of_Work>
                  </xsl:if>

                </ns0:Status>

                <xsl:variable name ="IsEffectivePositionPromary">
                  <xsl:choose>
                    <xsl:when test ="count(s0:All_Effective_Positions[s0:Primary_Job/text() = '1'])> 0">
                      <xsl:value-of select ="'true'"/>
                    </xsl:when>
                    <xsl:otherwise>
                      <xsl:value-of select ="'false'"/>
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>

                <xsl:variable name ="IsFutureEffectivePositionPromary">
                  <xsl:choose>
                    <xsl:when test ="count(s0:All_Future_Effective_Positions[s0:Future_Primary_Job/text() = '1'])> 0">
                      <xsl:value-of select ="'true'"/>
                    </xsl:when>
                    <xsl:otherwise>
                      <xsl:value-of select ="'false'"/>
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>

                <xsl:for-each select="s0:All_Effective_Positions">
                  <ns0:Position>
                    <ns0:Primary_Position>
                      <xsl:choose>
                        <xsl:when test="s0:Primary_Job/text() = '1'">
                          <xsl:value-of select="'true'" />
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="'false'" />
                        </xsl:otherwise>
                      </xsl:choose>
                    </ns0:Primary_Position>

                    <xsl:if test="s0:Business_Title">
                      <ns0:Business_Title>
                        <xsl:value-of select="s0:Business_Title/text()" />
                      </ns0:Business_Title>
                    </xsl:if>


                    <xsl:if test="../s0:Worker_Type/s0:ID[@s0:type='Worker_Type_ID']">
                      <ns0:Worker_Type>
                        <xsl:value-of select="../s0:Worker_Type/s0:ID[@s0:type='Worker_Type_ID']/text()" />
                      </ns0:Worker_Type>
                    </xsl:if>

                    <xsl:if test="s0:Supervisory_Organization/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Supervisory_Organization/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Cost_Center/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Cost_Center/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Company/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Company/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Talent_Program_Tracking/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Talent_Program_Tracking/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Business_Type_Tracking/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Business_Type_Tracking/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>

                    <xsl:if test="s0:Location/@s0:Descriptor">
                      <ns0:Business_Site_Name>
                        <xsl:value-of select="s0:Location/@s0:Descriptor" />
                      </ns0:Business_Site_Name>
                    </xsl:if>

                    <xsl:if test="../s0:Manager/s0:Manager_Employee_ID">
                      <ns0:Supervisor_ID>
                        <xsl:value-of select="../s0:Manager/s0:Manager_Employee_ID/text()" />
                      </ns0:Supervisor_ID>
                    </xsl:if>

                  </ns0:Position>
                </xsl:for-each>

                <xsl:for-each select="s0:All_Future_Effective_Positions">
                  <ns0:Position>

                    <xsl:choose>
                      <xsl:when test ="$IsEffectivePositionPromary = 'true'">
                        <ns0:Primary_Position>
                          <xsl:value-of select="'false'" />
                        </ns0:Primary_Position>
                      </xsl:when>
                      <xsl:otherwise>
                        <ns0:Primary_Position>
                          <xsl:choose>
                            <xsl:when test="s0:Future_Primary_Job/text() = '1'">
                              <xsl:value-of select="'true'" />
                            </xsl:when>
                            <xsl:otherwise>
                              <xsl:value-of select="'false'" />
                            </xsl:otherwise>
                          </xsl:choose>
                        </ns0:Primary_Position>
                      </xsl:otherwise>
                    </xsl:choose>


                    <xsl:if test="../s0:Worker_Type/s0:ID[@s0:type='Worker_Type_ID']">
                      <ns0:Worker_Type>
                        <xsl:value-of select="../s0:Worker_Type/s0:ID[@s0:type='Worker_Type_ID']/text()" />
                      </ns0:Worker_Type>
                    </xsl:if>
                    <xsl:if test="s0:Future_Supervisory_Organization/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Future_Supervisory_Organization/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Future_Cost_Center/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Future_Cost_Center/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Future_Company/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Future_Company/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Future_Talent_Program_Tracking/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Future_Talent_Program_Tracking/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>
                    <xsl:if test="s0:Future_Business_Type_Tracking/s0:ID[@s0:type='Organization_Reference_ID']">
                      <ns0:Organization_Data>
                        <ns0:Organization>
                          <xsl:value-of select="s0:Future_Business_Type_Tracking/s0:ID[@s0:type='Organization_Reference_ID']/text()" />
                        </ns0:Organization>
                      </ns0:Organization_Data>
                    </xsl:if>

                    <xsl:if test="s0:Future_Location/@s0:Descriptor">
                      <ns0:Business_Site_Name>
                        <xsl:value-of select="s0:Future_Location/@s0:Descriptor" />
                      </ns0:Business_Site_Name>
                    </xsl:if>


                    <xsl:if test="../s0:Manager/s0:Manager_Employee_ID">
                      <ns0:Supervisor_ID>
                        <xsl:value-of select="../s0:Manager/s0:Manager_Employee_ID/text()" />
                      </ns0:Supervisor_ID>
                    </xsl:if>
                  </ns0:Position>
                </xsl:for-each>


                <xsl:if test="s0:Contract_End_Date">
                  <ns0:Contract>
                    <ns0:End_Date>
                      <xsl:value-of select="s0:Contract_End_Date/text()" />
                    </ns0:End_Date>
                  </ns0:Contract>
                </xsl:if>

                <xsl:if test="s0:Image/s0:Base64/text()">
                  <ns0:Photo>
                    <ns0:Image>
                      <xsl:value-of select="s0:Image/s0:Base64/text()" />
                    </ns0:Image>
                  </ns0:Photo>
                </xsl:if>

                <xsl:if test ="s0:Workday_Account/s0:ID[@s0:type='System_User_ID']
                        or s0:Initials
                        or s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Organization_BreadCrumb
                        or s0:All_Future_Effective_Positions[1]/s0:Future_Organization_BreadCrumb
                        or s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Cost_Center/@s0:Descriptor
                        or s0:All_Future_Effective_Positions[1]/s0:Future_Cost_Center/@s0:Descriptor">
                  <ns0:Additional_Information>
                    <xsl:if test ="s0:Workday_Account/s0:ID[@s0:type='System_User_ID']">
                      <ns0:Account>
                        <ns0:UserName>
                          <xsl:value-of select="s0:Workday_Account/s0:ID[@s0:type='System_User_ID']/text()" />
                        </ns0:UserName>
                      </ns0:Account>
                    </xsl:if>
                    <xsl:if test ="s0:Initials">
                      <ns0:Personal>
                        <ns0:Name_Data>
                          <ns0:Initials>
                            <xsl:value-of select="s0:Initials/text()" />
                          </ns0:Initials>
                        </ns0:Name_Data>
                      </ns0:Personal>
                    </xsl:if>


                    <xsl:choose>
                      <xsl:when test ="s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Organization_BreadCrumb">
                        <ns0:Primary_Organization_BreadCrumb>
                          <xsl:value-of select="s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Organization_BreadCrumb"/>
                        </ns0:Primary_Organization_BreadCrumb>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:if test ="s0:All_Future_Effective_Positions[1]/s0:Future_Organization_BreadCrumb">
                          <ns0:Primary_Organization_BreadCrumb>
                            <xsl:value-of select="s0:All_Future_Effective_Positions[1]/s0:Future_Organization_BreadCrumb"/>
                          </ns0:Primary_Organization_BreadCrumb>
                        </xsl:if>
                      </xsl:otherwise>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test ="s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Cost_Center/@s0:Descriptor">
                        <ns0:Cost_Center>
                          <xsl:value-of select ="s0:All_Effective_Positions[s0:Primary_Job/text() = '1'][1]/s0:Cost_Center/@s0:Descriptor"/>
                        </ns0:Cost_Center>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:if test ="s0:All_Future_Effective_Positions[1]/s0:Future_Cost_Center/@s0:Descriptor">
                          <ns0:Cost_Center>
                            <xsl:value-of select ="s0:All_Future_Effective_Positions[1]/s0:Future_Cost_Center/@s0:Descriptor"/>
                          </ns0:Cost_Center>
                        </xsl:if>
                      </xsl:otherwise>
                    </xsl:choose>

                  </ns0:Additional_Information>
                </xsl:if>
              </ns0:Worker>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:for-each>
    </ns0:Worker_Sync>
  </xsl:template>
  <msxsl:script language="C#" implements-prefix="userCSharp">
    <![CDATA[


public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool LogicalLte(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 <= d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) <= 0;
	}
	return ret;
}


public string DateCurrentDate()
        {
            DateTime dt = DateTime.Now;
            string curdate = dt.ToString("yyyy-MM-dd-HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            string retval = curdate;
            return retval;
        }


public bool LogicalGt(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 > d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) > 0;
	}
	return ret;
}


]]>
  </msxsl:script>
</xsl:stylesheet>