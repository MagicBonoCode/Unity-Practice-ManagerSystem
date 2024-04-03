# Unity-Practice-ManagerSystem

이 프로젝트는 게임 제작 과정에서 필수적인 기능들을 정리하여 구현한 매니저 시스템입니다.

일반적인 프로젝트는 해당 매니저 시스템을 기반으로 개발됩니다.

### **프로젝트 정보**

엔진 : Unity

엔진 버전 : 2022.3.21f1

### **사용 Unity 패키지**

- Addressable

### **기능별 매니저**

- 매니저 관리: Managers.cs
- 리소스 관리: ResourceManager.cs
- 오브젝트 관리: ObjectManager.cs, PoolManager.cs
- 데이터 관리: DataManager.cs
- 이벤트 관리: EventManager.cs
- 씬 관리: SceneManagerEx.cs
- UI 관리: UIManager.cs
- 사운드 관리: SoundManager.cs

## 설명

### 매니저 관리

**관련 스크립트:** Managers.cs

**구성**

각 매니저들은 독립적으로 작동하며, Managers 클래스에서 싱글턴 패턴을 통해 효과적으로 관리됩니다. 'Instance' 속성을 통해 단 하나의 Managers 인스턴스만이 반환될 수 있도록 설계되었습니다.

"_Managers"라는 이름의 파괴되지 않는 GameObject가 생성되고, 해당 GameObject에는 Managers 컴포넌트가 추가되어 'Instance' 속성에 할당됩니다. 이렇게 함으로써 Managers 클래스의 싱글턴 인스턴스가 게임의 수명주기 동안 유지되며, 어디서든 전역적으로 접근 가능하게 됩니다.

**이점**

- **중복 생성 방지:** 싱글턴 패턴을 사용하면 애플리케이션에서 매니저들을 한 번만 생성하여 메모리와 자원을 효율적으로 관리할 수 있습니다.
- **전역적인 접근성:** 싱글턴으로 구현된 매니저들은 어디서든지 쉽게 접근할 수 있어 편리합니다. 이는 코드의 가독성을 향상시키고, 개발자들이 필요한 기능을 빠르게 찾고 사용할 수 있도록 합니다.
- **모듈화된 설계:** 각 매니저는 특정 기능을 담당하며, 이들을 모듈화하여 개발 및 유지보수를 용이하게 합니다. Managers 클래스는 이러한 모듈화된 매니저들을 통합하여 전체 시스템을 완성시키며, 코드의 구조를 단순화하고 유지보수성을 향상시킵니다.
- **통일된 접근성 제공:** Managers.cs에 다양한 매니저들을 포함시킴으로써, 시스템 전반에 걸쳐 일관된 접근 방식을 제공합니다. 이는 코드의 가독성을 향상시키고, 개발자들이 필요한 기능을 빠르게 찾고 사용할 수 있도록 합니다.

### **리소스 관리**

**관련 스크립트:** ResourceManager.cs

**구성**

ResourceManager 클래스는 게임에서 리소스를 로드하고 관리하는 데 사용됩니다.

리소스를 한 번에 불러와 관리하기 위해 Addressable 시스템을 사용합니다. 이를 통해 리소스를 비동기적으로 로드하고 효율적으로 관리할 수 있습니다. 또한, 로드한 리소스는 키와 Object로 구성된 ‘_resources’ 딕셔너리에 할당되어 사용됩니다.

**이점**

- **효율적인 리소스 관리:** 리소스 매니저를 사용하면 게임에서 필요한 리소스를 효율적으로 로드하고 관리할 수 있습니다. 리소스는 한 번 로드된 후에는 딕셔너리에 저장되어 재사용됩니다. 이를 통해 메모리와 자원을 효율적으로 관리할 수 있습니다.
- **비동기적 로드 지원:** Addressable API를 사용하여 리소스를 비동기적으로 로드합니다. 이는 게임의 성능을 향상시키고 로드 시간을 최소화하는 데 도움이 됩니다. 또한, 비동기적 로드는 게임의 로딩 화면을 보다 부드럽게 만들어줍니다.

### **오브젝트 관리**

**관련 스크립트:** ObjectManager.cs, PoolManager.cs, Poolable.cs, ResourceManager.cs

**구성**

ObjectManager 클래스는 게임 오브젝트의 생성 및 제거를 담당합니다. ResourceManager에서 생성된 오브젝트는 적절한 자료구조에 저장되고 관리됩니다. PoolManager 클래스는 게임 오브젝트의 풀링을 관리합니다. Original 게임 오브젝트의 복사본을 생성하여 풀을 초기화하고, Push와 Pop 메서드를 통해 게임 오브젝트를 풀에 반환하거나 풀에서 가져옵니다. 또한, ResourceManager에서는 리소스가 이미 생성된 경우에는 PoolManager에서 반환합니다.

**이점**

- **리소스 절약:** 풀링을 사용하여 게임 오브젝트를 재사용함으로써 메모리 및 자원을 효율적으로 관리할 수 있습니다. 게임 오브젝트를 반복적으로 생성하는 대신 미리 생성된 게임 오브젝트를 재활용함으로써 리소스 소비를 최소화할 수 있습니다.
- **성능 향상:** 풀링을 통해 게임 오브젝트를 미리 생성하고 재사용함으로써 게임의 성능을 향상시킬 수 있습니다. 게임 실행 중에 게임 오브젝트를 동적으로 생성하는 것보다 풀링된 게임 오브젝트를 사용하는 것이 더 효율적입니다.
- **관리 용이성:** ObjectManager와 PoolManager를 사용하여 게임 오브젝트의 생성, 제거 및 재사용을 효과적으로 관리할 수 있습니다. 이를 통해 게임의 개발 및 유지보수가 용이해지며, 코드의 가독성과 관리가 향상됩니다.

### **데이터 관리**

**관련 스크립트:** DataManager.cs

**구성**

DataManager 클래스는 데이터를 로드하고 관리합니다. ScriptableObject를 통해 로드된 데이터를 알맞은 Dictionary에 저장하고 관리합니다.

**이점**

- **데이터 관리:** DataManager 클래스는 게임에서 필요한 데이터를 로드하고 관리합니다. ScriptableObject를 사용하여 데이터를 구조화하고, Dictionary를 활용하여 효율적으로 관리합니다.

### **이벤트 관리**

**관련 스크립트:** EventManager.cs

**구성**

EventManager 클래스는 게임 내 이벤트를 관리합니다. 이벤트는 이름에 해당하는 특정 작업(Action)을 수행할 수 있도록 등록하고, 트리거하여 실행할 수 있습니다.

**이점**

- **이벤트 중앙 집중화:** EventManager를 사용하면 게임 내의 다양한 이벤트를 중앙 집중화하여 관리할 수 있습니다. 이를 통해 이벤트 관련 코드를 한 곳에 모아 관리할 수 있으며, 코드의 일관성과 유지보수성을 향상시킵니다.
- **동적 이벤트 추가 및 제거:** AddEvent 및 RemoveEvent 메서드를 사용하여 이벤트를 동적으로 추가하거나 제거할 수 있습니다. 이는 게임의 실행 중에 이벤트를 유연하게 관리할 수 있도록 합니다.
- **이벤트 트리거:** TriggerEvent 메서드를 사용하여 등록된 이벤트를 트리거하여 실행할 수 있습니다. 이는 게임의 여러 부분에서 필요한 이벤트를 쉽게 호출할 수 있도록 합니다.
- **메모리 관리:** EventManager는 필요 없어진 이벤트를 Clear 메서드를 통해 명시적으로 제거할 수 있습니다. 이를 통해 메모리 누수를 방지하고 게임의 성능을 유지할 수 있습니다.

### **씬 관리**

**관련 스크립트:** SceneManagerEx.cs

**구성**

SceneManagerEx 클래스는 Unity의 Scene을 관리합니다. 특정 Scene을 로드하는데 사용되며, 필요에 따라 비동기적으로 로드할 수 있습니다.

**이점**

- **편리한 Scene 로드:** LoadScene 메서드를 통해 특정 Scene을 로드할 수 있습니다. 필요에 따라 비동기적으로 로드할지 동기적으로 로드할지 선택할 수 있습니다.
- **유연성:** SceneManagerEx는 Define.Scene 열거형을 사용하여 Scene 이름을 동적으로 가져오는 방식으로 유연성을 제공합니다. 새로운 Scene을 추가하거나 Scene 이름을 변경할 때 해당 열거형을 업데이트함으로써 손쉽게 관리할 수 있습니다.

### **UI 관리**

**관련 스크립트:** UIManager.cs

**구성**

UIManager 클래스는 게임의 UI를 관리합니다. Scene UI와 Popup UI를 표시하고, SubUI 및 WorldSpace UI를 생성할 수 있습니다.

**이점**

- **유연한 UI 관리:** UIManager를 사용하면 Scene UI 및 Popup UI를 쉽게 표시하고 관리할 수 있습니다. ShowSceneUI 및 ShowPopupUI 메서드를 사용하여 원하는 UI를 인스턴스화하고 화면에 표시할 수 있습니다.
- **Popup UI 스택 관리:** Popup UI를 스택으로 관리하여 여러 개의 팝업이 동시에 표시될 때 사용자 경험을 향상시킬 수 있습니다. ClosePopupUI 및 CloseAllPopupUI 메서드를 사용하여 팝업 UI를 닫고, Clear 메서드를 사용하여 UI를 초기화할 수 있습니다.

### **사운드 관리**

**관련 스크립트:** SoundManager.cs

**구성**

SoundManager 클래스는 게임의 사운드를 관리합니다. 게임에서 사용되는 모든 사운드 클립을 로드하고 재생할 수 있습니다.

**이점**

- **사운드 관리 편의성:** SoundManager를 사용하여 게임에서 사용되는 모든 사운드 클립을 중앙 집중식으로 관리할 수 있습니다. 게임 내의 여러 오디오 소스를 효율적으로 활용하여 사운드를 재생할 수 있습니다.
- **다양한 사운드 재생 기능:** 배경 음악과 효과음을 구분하여 재생할 수 있습니다. 배경 음악은 루프로 설정하여 지속적으로 재생되며, 효과음은 일회성으로 재생됩니다.
